using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeTCindyAutoInstallerGUI
{
    public partial class Form1 : Form
    {
        private readonly Uri default_path_Cinderella = new Uri("https://beta.cinderella.de/Cinderella-3.0b.2085-64bit.exe");
        private readonly Uri default_path_kettex = new Uri("https://github.com/ketpic/kettex/releases/download/v0.20240318/KeTTeX-windows-20240318.zip");
        private readonly Uri default_path_R = new Uri("https://cran.r-project.org/bin/windows/base/old/4.4.2/R-4.4.2-win.exe");
        private readonly Uri default_path_sumatra = new Uri("https://www.sumatrapdfreader.org/dl/rel/3.5.2/SumatraPDF-3.5.2-64-install.exe");
        //private readonly Uri default_path_maxima = new Uri("https://zenlayer.dl.sourceforge.net/project/maxima/Maxima-Windows/5.47.0-Windows/maxima-5.47.0-win64.exe?viasf=1");
        private readonly Uri default_path_maxima = new Uri("https://sourceforge.net/projects/maxima/files/Maxima-Windows/5.47.0-Windows/maxima-5.47.0-win64.exe/download");
        private readonly Uri default_path_ketcindy = new Uri("https://github.com/ketpic/ketcindy/archive/refs/tags/4.4.85.zip");

        private Uri path_Cinderella;
        private Uri path_kettex;
        private Uri path_R;
        private Uri path_sumatra;
        private Uri path_maxima;
        private Uri path_ketcindy;

        private readonly HtmlParser htmlParser = new HtmlParser();

        private readonly HttpClient httpClient = new HttpClient
        {
            Timeout = Timeout.InfiniteTimeSpan,
        };
        public Form1()
        {
            Text = "KeTCindy Auto Installer on GUI";

            InitializeComponent();
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            WriteLine("ソフトウェアの更新を確認しています...");

            path_Cinderella = default_path_Cinderella;
            path_kettex = default_path_kettex;
            path_R = default_path_R;
            path_sumatra = default_path_sumatra;
            path_maxima = default_path_maxima;
            path_ketcindy = default_path_ketcindy;

            await CheckUpdateCinderella2();
            await CheckUpdateKeTTeX();
            await CheckUpdateR();
            CheckUpdateMaxima(); // not need await
            await CheckUpdateKeTCindy();

            InstallButton.Enabled = true;
        }

        private async void InstallButton_Click(object sender, EventArgs e)
        {
            WriteLine("インストールが開始されました。");
            InstallButton.Enabled = false;

            await Install();

            InstallButton.Enabled = true;
        }
        private async Task<bool> Install()
        {
            WriteLine($"一時フォルダのパス: {System.IO.Path.GetTempPath()}");

            DirectoryInfo TempFolder = new DirectoryInfo(Path.Combine(System.IO.Path.GetTempPath(), "KETCINDYINSTALLER"));

            try
            {
                if (TempFolder.Exists)
                {
                    WriteLine("一時フォルダが既に存在します。");
                    WriteLine($"[エラー] 一時フォルダを削除する必要があります。 ({TempFolder.Name})");

                    DialogResult result = MessageBox.Show($"一時フォルダを削除しますか？ ({TempFolder.Name})?",
                        "警告",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button2
                    );

                    if (result == DialogResult.Yes)
                    {
                        TempFolder.Delete(true);

                    }
                    else
                    {
                        WriteLine("インストールがキャンセルされました。");
                        return true;
                    }
                }

                TempFolder.Create();
                WriteLine("一時フォルダが正常に作成されました。");


                // Cinderella
                if (cinderella2ToolStripMenuItem.Checked)
                {
                    WriteLine("Cinderellaをダウンロードしています。");
                    if (await InstallExecutable(TempFolder, path_Cinderella, "-q"))
                    {
                        WriteLine("Cinderellaのインストールに失敗しました。");
                        return true;
                    }
                    WriteLine("Cinderellaのダウンロードが完了しました。");
                }
                else
                {
                    WriteLine("Cinderellaのインストールをスキップしました。");
                }

                /////////////////////////////////////////
                /// KeTTeX
                /////////////////////////////////////////
                if (keTTeXToolStripMenuItem.Checked)
                {
                    // download KeTTeX
                    WriteLine("KeTTeXをダウンロードしています...");
                    await DownloadFile(path_kettex, TempFolder, Path.GetFileName(path_kettex.AbsolutePath));


                    // Install KeTTeX
                    WriteLine("KeTTeXをインストールしています...");
                    var kettexInstallerDirectory = new DirectoryInfo("C:\\KETTEX-INSTALLER");

                    if (kettexInstallerDirectory.Exists)
                    {
                        WriteLine("KeTTeXのインストールフォルダが既に存在します。");
                        WriteLine($"フォルダを削除する必要があります。 ({kettexInstallerDirectory.FullName})");

                        DialogResult result = MessageBox.Show($"KeTTeXフォルダを削除しますか？ ({kettexInstallerDirectory.Name})?",
                             "警告",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Error,
                             MessageBoxDefaultButton.Button2
                        );

                        if (result == DialogResult.Yes)
                        {
                            kettexInstallerDirectory.Delete(true);
                        }
                        else
                        {
                            WriteLine("インストールがキャンセルされました。");
                            return true;
                        }
                    }

                    // zip file extract
                    System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(TempFolder.FullName, Path.GetFileName(path_kettex.AbsolutePath)), kettexInstallerDirectory.FullName);

                    // run cmd file
                    var process_kettex = Process.Start(new ProcessStartInfo
                    {
                        FileName = Path.Combine(kettexInstallerDirectory.FullName, "kettexinst.cmd"),
                        UseShellExecute = true,
                        Verb = "RunAs",
                    });

                    if (process_kettex == null)
                    {
                        WriteLine("KeTTeXのインストールプロセスが開始されませんでした。");
                        return true;
                    }

                    // error handling kettex
                    process_kettex.WaitForExit();
                    if (process_kettex.ExitCode != 0)
                    {
                        WriteLine("KeTTeXのインストールプロセスが終了コード0を返しませんでした。");
                        return true;
                    }
                    process_kettex.Close();

                    kettexInstallerDirectory.Delete(true);
                    WriteLine("KeTTeXのインストールが正常に完了しました。");
                }
                else
                {
                    WriteLine("KeTTeXのインストールをスキップしました。");
                }

                // R
                if (rToolStripMenuItem.Checked)
                {
                    WriteLine("Rをダウンロードしています...");
                    if (await InstallExecutable(TempFolder, path_R, "/silent"))
                    {
                        WriteLine("Rのインストールに失敗しました。");
                        return true;
                    }
                    WriteLine("Rのインストールが正常に完了しました。");
                }
                else
                {
                    WriteLine("Rのインストールをスキップしました。");
                }

                // SumatraPDF
                if (sumatraPDFToolStripMenuItem.Checked)
                {
                    WriteLine("SumatraPDFをダウンロードしています...");
                    if (await InstallExecutable(TempFolder, path_sumatra, "-s -d \"C:\\Program Files\\SumatraPDF\""))
                    {
                        WriteLine("SumatraPDFのインストールに失敗しました。");
                        return true;
                    }
                    WriteLine("SumatraPDFのインストールが正常に完了しました。");
                }
                else
                {
                    WriteLine("SumatraPDFのインストールをスキップしました。");
                }

                // Maxima
                if (maximaToolStripMenuItem.Checked)
                {
                    WriteLine("Maximaをインストールしています...");
                    await InstallExecutable(TempFolder, path_maxima, "/S", "maxima.exe");
                    WriteLine("Maximaのインストールが正常に完了しました。");
                }
                else
                {
                    WriteLine("Maximaのインストールをスキップしました。");
                }

                // download KeTCindy
                if (keTCindyToolStripMenuItem.Checked)
                {
                    WriteLine("KeTCindyをダウンロードしています...");
                    await DownloadFile(path_ketcindy, TempFolder, Path.GetFileName(path_ketcindy.AbsolutePath));

                    // install KeTCindy
                    WriteLine("KeTCindyをインストールしています...");
                    var ketcindyInstallerDirectory = new DirectoryInfo("C:\\ketcindy");

                    if (ketcindyInstallerDirectory.Exists)
                    {
                        WriteLine("KeTCindyのインストールフォルダが既に存在します。");
                        WriteLine($"フォルダを削除する必要があります。 ({ketcindyInstallerDirectory.FullName})");

                        DialogResult result = MessageBox.Show($"KeTCindyフォルダを削除しますか？ ({TempFolder.Name})?",
                            "警告",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2
                        );

                        if (result == DialogResult.Yes)
                        {
                            ketcindyInstallerDirectory.Delete(true);
                        }
                        else
                        {
                            WriteLine("インストールがキャンセルされました。");
                            return true;
                        }
                    }
                    System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(TempFolder.FullName, Path.GetFileName(path_ketcindy.AbsolutePath)), Path.Combine(TempFolder.FullName, "ketcindy"));

                    var tempKetcindyFolder = new DirectoryInfo(Path.Combine(TempFolder.FullName, "ketcindy"));
                    Directory.Move(Path.Combine(TempFolder.FullName, "ketcindy", tempKetcindyFolder.GetDirectories()[0].Name), ketcindyInstallerDirectory.FullName);


                    WriteLine("ketcindysettings.cdyを開いています...");
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = Path.Combine(ketcindyInstallerDirectory.FullName, "doc", "ketcindysettings.cdy"),
                        UseShellExecute = true
                    });

                    await Task.Run(() =>
                    {
                        MessageBox.Show("「Kettex」「Mkinit」「Update」「Work」を順にクリックしてください。");
                    });

                    // Create Working folder shortcut
                    WriteLine("作業フォルダのショートカットを作成しています...");
                    var shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ketcindy");
                    var shortcutTarget = ketcindyInstallerDirectory.FullName;
                    CreateShortcut(shortcutPath, shortcutTarget);
                }
                else
                {
                    WriteLine("KeTCindyのインストールをスキップしました。");
                }

                // Cleanup TEMP folder
                WriteLine("TEMPフォルダをクリーンアップしています");
                TempFolder.Delete(true);

                WriteLine("!!! インストールが正常に完了しました。");
            }
            catch (Exception ex)
            {
                WriteLine($"例外が検出されました: {ex}");
                WriteLine("エラーが発生しました。");
                return true;
            }

            return false;
        }

        private void WriteLine(string text)
        {
            StatusBox.Text += text + "\r\n";
        }

        private async Task DownloadFile(Uri target, DirectoryInfo saveTo, string fileName)
        {
            await Task.Run(async () =>
            {
                WriteLine($"Downloading {target} to {saveTo}\\{fileName}");

                var request = new HttpRequestMessage(HttpMethod.Get, target);
                request.Headers.Add("User-Agent", "curl/8.12.1");
                request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");

                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                using (var fileStream = File.Create(saveTo.FullName + "\\" + fileName))
                using (var httpStream = await response.Content.ReadAsStreamAsync())
                {
                    httpStream.CopyTo(fileStream);
                    fileStream.Flush();
                }

                WriteLine($"Downloaded successfully.");
            });
        }

        private void CreateShortcut(string shortcutPath, string target)
        {
            var type = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
            dynamic wsh = Activator.CreateInstance(type);

            if (!shortcutPath.EndsWith(".lnk"))
            {
                shortcutPath += ".lnk";
            }

            var shortcut = wsh.CreateShortcut(shortcutPath);
            shortcut.TargetPath = target;

            shortcut.Save();

            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wsh);
        }

        private async Task<bool> InstallExecutable(DirectoryInfo TempFolder, Uri url, string argument, string tempPath = null)
        {
            // Download
            await DownloadFile(url, TempFolder, tempPath ?? Path.GetFileName(url.AbsolutePath));


            // Install install
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(TempFolder.FullName, tempPath ?? Path.GetFileName(url.AbsolutePath)),
                UseShellExecute = true,
                Verb = "RunAs",
                Arguments = argument
            });

            if (process == null)
            {
                WriteLine("Install proceess has not been started.");
                return true;
            }

            // error Handling 
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                WriteLine("install proceess has not returned exit code 0.");
                return true;
            }

            process.Close();
            return false;
        }

        private async Task<List<ReleaseObject>> GetReleaseFromGitHub(string ApiUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ApiUrl);
            request.Headers.Add("User-Agent", "KeTCindy Auto Installer");
            request.Headers.Add("X-GitHub-Api-Version", "2022-11-28");

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Response is not success(2xx).");
            }

            return await response.Content.ReadFromJsonAsync<List<ReleaseObject>>();
        }

        private async Task CheckUpdateKeTCindy()
        {
            var list = await GetReleaseFromGitHub("https://api.github.com/repos/ketpic/ketcindy/releases");

            // latest 
            path_ketcindy = new Uri(list[0].zipball_url);
            WriteLine($"最新のKeTCindy: \"{list[0].name}\"");

            // create menu
            list.ForEach(element =>
            {
                var versionItem = KeTCindyVersionToolStripMenuItem.DropDownItems.Add($"{element.name} ({element.tag_name})");
                versionItem.ToolTipText = $"url: {element.zipball_url}";

                versionItem.Click += (sender, e) =>
                {
                    WriteLine($"Changed KeTCindy \"{element.name}\" (url: {element.zipball_url})");
                    path_ketcindy = new Uri(element.zipball_url);
                };
            });
        }
        private async Task CheckUpdateKeTTeX()
        {
            var list = await GetReleaseFromGitHub("https://api.github.com/repos/ketpic/kettex/releases");

            list[0].assets.ForEach(element =>
            {
                if (element.name.Contains("windows"))
                {
                    path_kettex = new Uri(element.browser_download_url);
                }
            });

            WriteLine($"最新のKeTTeX: \"{list[0].name}\" ({list[0].tag_name})");

            // create menu
            list.ForEach(list_element =>
            {
                if (list_element.assets.Count == 0)
                {
                    return;
                }


                list_element.assets.ForEach(assets_element =>
                {
                    if (assets_element.name.Contains("windows"))
                    {
                        var versionItem = KeTTeXVersionToolStripMenuItem.DropDownItems.Add($"{list_element.name} ({list_element.tag_name})");

                        versionItem.Click += (sender, e) =>
                        {
                            WriteLine($"Changed \"{list_element.name}\" (url: {assets_element.browser_download_url})");

                            path_kettex = new Uri(assets_element.browser_download_url);
                        };

                    }
                });
            });
        }

        private async Task CheckUpdateCinderella2()
        {
            try
            {
                Uri target = new Uri("https://beta.cinderella.de/");
                string htmlstr = await httpClient.GetStringAsync(target);

                var doc = htmlParser.ParseDocument(htmlstr);
                var link = doc.QuerySelector("body > ul > li:nth-child(2) > a").GetAttribute("href");
                var latestUri = new Uri(target, link);

                path_Cinderella = latestUri;
                WriteLine($"最新版のCinderella2: \"{latestUri}\"");

                var latestItem = CinderellaVersionToolStripMenuItem.DropDownItems.Add($"最新版 ({latestUri})");
                latestItem.Click += (sender, e) =>
                {
                    WriteLine($"Cinderella2を最新版に変更しました。 (url: {latestUri})");

                    path_Cinderella = latestUri;
                };

                var checkedVersionItem = CinderellaVersionToolStripMenuItem.DropDownItems.Add($"確認済み ({default_path_Cinderella})");
                checkedVersionItem.Click += (sender, e) =>
                {
                    WriteLine($"Cinderella2を確認済みバージョンに変更しました。 ({default_path_Cinderella})");

                    path_Cinderella = default_path_Cinderella;
                };
            }
            catch (Exception)
            {
                WriteLine($"例外が発生したため、Cinderella2は確認済みバージョンを使用します。");

                path_Cinderella = default_path_Cinderella;
            }
        }

        private async Task CheckUpdateR()
        {
            try
            {
                Uri target = new Uri("https://cran.r-project.org/bin/windows/base/release.html");
                string htmlContent = await httpClient.GetStringAsync(target);

                var doc = htmlParser.ParseDocument(htmlContent);
                var metaTag = doc.QuerySelector("meta[http-equiv=Refresh]") as IHtmlMetaElement;
                var match = Regex.Match(metaTag.Content, @"(?i)url=([0-9a-zA-Z-.,_~/+]+);?");

                if (!match.Success)
                    throw new Exception();

                var latestUri = new Uri(target, match.Groups[1].Value.Trim());
                path_R = latestUri;

                WriteLine($"最新版のR: \"{latestUri}\"");

                var latestItem = RVersionToolStripMenuItem.DropDownItems.Add($"最新版 ({latestUri})");
                latestItem.Click += (sender, e) =>
                {
                    WriteLine($"Rを最新版に変更しました。 ({latestUri})");

                    path_R = latestUri;
                };

                var checkedVersionItem = RVersionToolStripMenuItem.DropDownItems.Add($"確認済み ({default_path_R})");
                checkedVersionItem.Click += (sender, e) =>
                {
                    WriteLine($"Rを確認済みバージョンに変更しました。 ({default_path_R})");

                    path_R = default_path_R;
                };
            }
            catch (Exception)
            {
                WriteLine($"例外が発生したため、Rは確認済みバージョンを使用します。");

                path_R = default_path_R;
                throw;
            }
        }

        private void CheckUpdateMaxima()
        {
            try
            {
                var latestUri = new Uri("https://sourceforge.net/projects/maxima/files/latest/download");
                path_maxima = latestUri;

                WriteLine($"最新版のMaxima: \"{latestUri}\"");

                var latestItem = MaximaVersionToolStripMenuItem.DropDownItems.Add($"最新版 ({latestUri})");
                latestItem.Click += (sender, e) =>
                {
                    WriteLine($"Maximaを最新版に変更しました。 ({latestUri})");

                    path_maxima = latestUri;
                };

                var checkedVersionItem = MaximaVersionToolStripMenuItem.DropDownItems.Add($"確認済み ({default_path_maxima})");
                checkedVersionItem.Click += (sender, e) =>
                {
                    WriteLine($"Maximaを確認済みバージョンに変更しました。 ({default_path_maxima})");

                    path_maxima = default_path_maxima;
                };
            }
            catch (Exception)
            {
                WriteLine($"例外が発生したため、Maximaは確認済みバージョンを使用します。");

                path_maxima = default_path_maxima;
                throw;
            }
        }
    }
}

