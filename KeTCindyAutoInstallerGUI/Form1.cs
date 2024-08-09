using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeTCindyAutoInstallerGUI
{
    public partial class Form1 : Form
    {
        private Uri path_Cinderella = new Uri("https://beta.cinderella.de/Cinderella-3.0b.2085-64bit.exe");
        private Uri path_kettex = new Uri("https://github.com/ketpic/kettex/releases/download/v0.20240318/KeTTeX-windows-20240318.zip");
        private Uri path_R = new Uri("https://cran.r-project.org/bin/windows/base/R-4.4.1-win.exe");
        private Uri path_sumatra = new Uri("https://www.sumatrapdfreader.org/dl/rel/3.5.2/SumatraPDF-3.5.2-64-install.exe");
        private Uri path_maxima = new Uri("https://zenlayer.dl.sourceforge.net/project/maxima/Maxima-Windows/5.47.0-Windows/maxima-5.47.0-win64.exe?viasf=1");
        private Uri path_ketcindy = new Uri("https://github.com/ketpic/ketcindy/archive/refs/tags/4.4.85.zip");

        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();

            WriteLine("Checking for software updates...");
            CheckUpdateKeTCindy();
            CheckUpdateKeTTeX();

            WriteLine("Install start waiting...");

        }

        private async void InstallButton_Click(object sender, EventArgs e)
        {
            WriteLine("Install started");
            InstallButton.Enabled = false;

            if (await Install())
            {
                WriteLine("Install was not finished.");
            }
            else
            {
                WriteLine("Install had been finished successfully.");
            }

            InstallButton.Enabled = true;
        }
        private async Task<bool> Install()
        {
            WriteLine($"Temp path: {System.IO.Path.GetTempPath()}");

            DirectoryInfo TempFolder = new DirectoryInfo(System.IO.Path.GetTempPath() + "KETCINDYINSTALLER");

            try
            {
                if (TempFolder.Exists)
                {
                    WriteLine("TEMP Path exists already.");
                    WriteLine($"[ERROR] You should delete the path. ({TempFolder.Name})");
#if DEBUG
                    WriteLine($"You are in debug mode! delete TEMP Folder");

                    TempFolder.Delete(true);
#else
                    return true;
#endif
                }

                TempFolder.Create();
                WriteLine("TEMP folder was created successfully.");


                // Cinderella
                WriteLine("Cinderella is downloading ...");
                if (await InstallExecutable(TempFolder, path_Cinderella, "-q"))
                {
                    WriteLine("Cinderella install has been failed.");
                    return true;
                }
                WriteLine("KeTCindy install has been finished successfully.");

                // download KeTTeX
                WriteLine("KeTTeX is downloading ...");
                await DownloadFile(path_kettex, TempFolder, Path.GetFileName(path_kettex.AbsolutePath));


                // Install KeTTeX
                WriteLine("KeTTeX is installing ...");
                var kettexInstallerDirectory = new DirectoryInfo("C:\\KETTEX-INSTALLER");

                if (kettexInstallerDirectory.Exists)
                {
                    WriteLine("KeTTeX install folder exists already.");
                    WriteLine($"You should delete the folder. ({kettexInstallerDirectory.FullName})");
#if DEBUG
                    WriteLine($"You are in debug mode! delete the folder");
                    kettexInstallerDirectory.Delete(true);
#else
                    return true;
#endif
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
                    WriteLine("KeTTeX install proceess has not been started.");
                    return true;
                }

                // error handling kettex
                process_kettex.WaitForExit();
                if (process_kettex.ExitCode != 0)
                {
                    WriteLine("KeTTeX install proceess has not returned exit code 0.");
                    return true;
                }
                process_kettex.Close();
                WriteLine("KeTTeX install has been finished successfully.");

                // R
                WriteLine("R is downloading ...");
                if (await InstallExecutable(TempFolder, path_R, "/silent"))
                {
                    WriteLine("R install has been failed.");
                    return true;
                }
                WriteLine("R install has been finished successfully.");

                // SumatraPDF
                WriteLine("SumatraPDF is downloading ...");
                if (await InstallExecutable(TempFolder, path_sumatra, "-s -d \"C:\\Program Files\\SumatraPDF\""))
                {
                    WriteLine("SumatraPDF install has been failed.");
                    return true;
                }
                WriteLine("SumatraPDF install has been finished successfully.");

                // Maxima
                WriteLine("Maxima is installing ...");
                await InstallExecutable(TempFolder, path_maxima, "/S");
                WriteLine("Maxima install has been finished successfully.");

                // download KeTCindy
                WriteLine("KeTCindy is downloading ...");
                await DownloadFile(path_ketcindy, TempFolder, Path.GetFileName(path_ketcindy.AbsolutePath));

                // install KeTCindy
                WriteLine("KeTCindy is installing ...");
                var ketcindyInstallerDirectory = new DirectoryInfo("C:\\ketcindy");

                if (ketcindyInstallerDirectory.Exists)
                {
                    WriteLine("KeTCindy install folder exists already.");
                    WriteLine($"You should delete the folder. ({ketcindyInstallerDirectory.FullName})");
#if DEBUG
                    WriteLine($"You are in debug mode! delete the folder");
                    ketcindyInstallerDirectory.Delete(true);
#else
                    return true;
#endif
                }
                System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(TempFolder.FullName, Path.GetFileName(path_ketcindy.AbsolutePath)), Path.Combine(TempFolder.FullName, "ketcindy"));

                var tempKetcindyFolder = new DirectoryInfo(Path.Combine(TempFolder.FullName, "ketcindy"));
                Directory.Move(Path.Combine(TempFolder.FullName, "ketcindy", tempKetcindyFolder.GetDirectories()[0].Name), ketcindyInstallerDirectory.FullName);


                WriteLine("ketcindysettings.cdy is opening...");
                Process.Start(new ProcessStartInfo()
                {
                    FileName = Path.Combine(ketcindyInstallerDirectory.FullName, "doc", "ketcindysettings.cdy"),
                    UseShellExecute = true
                });

                await Task.Run(() =>
                {
                    MessageBox.Show("Click on \"Kettex\" \"Mkinit\" \"Update\" \"Work\"");
                });

                // Create Working folder shortcut
                WriteLine("Work folder shortcut is creating...");
                var shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ketcindy");
                var shortcutTarget = ketcindyInstallerDirectory.FullName;
                CreateShortcut(shortcutPath, shortcutTarget);

                // Cleanup TEMP folder
                WriteLine("Cleanup TEMP folder");
                TempFolder.Delete(true);
                kettexInstallerDirectory.Delete(true);
            }
            catch (Exception ex)
            {
                WriteLine($"Exception detected: {ex}");
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
                request.Headers.Add("User-Agent", "KeTCindy Auto Installer");
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

        private async Task<bool> InstallExecutable(DirectoryInfo TempFolder, Uri url, string argument)
        {
            // Download
            await DownloadFile(url, TempFolder, Path.GetFileName(url.AbsolutePath));


            // Install install
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(TempFolder.FullName, Path.GetFileName(url.AbsolutePath)),
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

        private async void CheckUpdateKeTCindy()
        {
            var list = await GetReleaseFromGitHub("https://api.github.com/repos/ketpic/ketcindy/releases");

            // latest 
            path_ketcindy = new Uri(list[0].zipball_url);
            WriteLine($"Latest KeTCindy is \"{list[0].name}\"");

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

        private async void CheckUpdateKeTTeX()
        {
            var list = await GetReleaseFromGitHub("https://api.github.com/repos/ketpic/kettex/releases");

            list[0].assets.ForEach(element =>
            {
                if (element.name.Contains("windows"))
                {
                    path_kettex = new Uri(element.browser_download_url);
                }
            });

            WriteLine($"Latest KeTTeX is \"{list[0].name}\" ({list[0].tag_name})");

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

    }
}

