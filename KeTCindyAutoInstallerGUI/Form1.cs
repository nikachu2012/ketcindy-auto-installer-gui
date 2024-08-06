using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeTCindyAutoInstallerGUI
{
    public partial class Form1 : Form
    {
        private readonly Uri path_Cinderella = new Uri("https://beta.cinderella.de/Cinderella-3.0b.2085-64bit.exe");
        private readonly Uri path_kettex = new Uri("https://github.com/ketpic/kettex/releases/download/v0.20240318/KeTTeX-windows-20240318.zip");
        private readonly Uri path_R = new Uri("https://cran.r-project.org/bin/windows/base/R-4.4.1-win.exe");
        private readonly Uri path_sumatra = new Uri("https://www.sumatrapdfreader.org/dl/rel/3.5.2/SumatraPDF-3.5.2-64-install.exe");
        private readonly Uri path_maxima = new Uri("https://zenlayer.dl.sourceforge.net/project/maxima/Maxima-Windows/5.47.0-Windows/maxima-5.47.0-win64.exe?viasf=1");
        private readonly Uri path_ketcindy = new Uri("https://github.com/ketpic/ketcindy/archive/refs/tags/4.4.85.zip");

        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
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
                    WriteLine($"You should delete TEMP path. ({TempFolder.Name})");
#if DEBUG
                    WriteLine($"You are in debug mode! delete TEMP Folder");

                    TempFolder.Delete(true);
#else
                    return true;
#endif
                }

                TempFolder.Create();
                WriteLine("TEMP folder was created successfully.");


                // Download Cinderella
                WriteLine("Cinderella is downloading ...");
                await Task.Run(async () =>
                {
                    await DownloadFile(path_Cinderella, TempFolder, Path.GetFileName(path_Cinderella.AbsolutePath));
                });

                // Install cinderella
                WriteLine("Cinderella is installing ...");
                var process_cinderella = Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(TempFolder.FullName, Path.GetFileName(path_Cinderella.AbsolutePath)),
                    UseShellExecute = true,
                    Verb = "RunAs",
                    Arguments = "-q"
                });

                if (process_cinderella == null)
                {
                    WriteLine("Cinderella install proceess has not been started.");
                    return true;
                }

                // error Handling KetCindy 
                process_cinderella.WaitForExit();

                if (process_cinderella.ExitCode != 0)
                {
                    WriteLine("KeTCindy install proceess has not returned exit code 0.");
                    return true;
                }

                process_cinderella.Close();
                WriteLine("KeTCindy install has been finished successfully.");

                // download KeTTeX
                WriteLine("KeTTeX is downloading ...");
                await Task.Run(async () =>
                {
                    await DownloadFile(path_kettex, TempFolder, Path.GetFileName(path_kettex.AbsolutePath));
                });


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

                // Download R
                WriteLine("R is downloading ...");
                await Task.Run(async () =>
                {
                    await DownloadFile(path_R, TempFolder, Path.GetFileName(path_R.AbsolutePath));
                });

                // Install R
                WriteLine("R is installing ...");
                var process_R = Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(TempFolder.FullName, Path.GetFileName(path_R.AbsolutePath)),
                    UseShellExecute = true,
                    Verb = "RunAs",
                    Arguments = "/silent"
                });

                if (process_R == null)
                {
                    WriteLine("R install proceess has not been started.");
                    return true;
                }

                // error Handling R 
                process_R.WaitForExit();
                if (process_R.ExitCode != 0)
                {
                    WriteLine("R install proceess has not returned exit code 0.");
                    return true;
                }
                process_R.Close();
                WriteLine("R install has been finished successfully.");

                // download SumatraPDF
                WriteLine("SumatraPDF is downloading ...");
                await Task.Run(async () =>
                {
                    await DownloadFile(path_sumatra, TempFolder, Path.GetFileName(path_sumatra.AbsolutePath));
                });

                // Install SumatraPDF
                WriteLine("SumatraPDF is installing ...");
                var process_SumatraPDF = Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(TempFolder.FullName, Path.GetFileName(path_sumatra.AbsolutePath)),
                    UseShellExecute = true,
                    Verb = "RunAs",
                    Arguments = "-s -d \"C:\\Program Files\\SumatraPDF\""
                });

                if (process_SumatraPDF == null)
                {
                    WriteLine("SumatraPDF install proceess has not been started.");
                    return true;
                }

                // error Handling SumatraPDF
                process_SumatraPDF.WaitForExit();
                if (process_SumatraPDF.ExitCode != 0)
                {
                    WriteLine("SumatraPDF install proceess has not returned exit code 0.");
                    return true;
                }
                process_SumatraPDF.Close();
                WriteLine("SumatraPDF install has been finished successfully.");

                // download Maxima
                WriteLine("Maxima is downloading ...");
                await Task.Run(async () =>
                {
                    await DownloadFile(path_maxima, TempFolder, Path.GetFileName(path_maxima.AbsolutePath));
                });

                // Install Maxima
                WriteLine("Maxima is installing ...");
                var process_maxima = Process.Start(new ProcessStartInfo
                {
                    FileName = Path.Combine(TempFolder.FullName, Path.GetFileName(path_maxima.AbsolutePath)),
                    UseShellExecute = true,
                    Verb = "RunAs",
                    Arguments = "/S"
                });

                if (process_maxima == null)
                {
                    WriteLine("Maxima install proceess has not been started.");
                    return true;
                }

                // error handling Maxima
                process_maxima.WaitForExit();
                if (process_maxima.ExitCode != 0)
                {
                    WriteLine("Maxima install proceess has not returned exit code 0.");
                    return true;
                }
                process_maxima.Close();
                WriteLine("Maxima install has been finished successfully.");

                // download KeTCindy
                WriteLine("KeTCindy is downloading ...");
                await Task.Run(async () =>
                {
                    await DownloadFile(path_ketcindy, TempFolder, Path.GetFileName(path_ketcindy.AbsolutePath));
                });

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
                createShortcut(shortcutPath, shortcutTarget);

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
            StatusBox.Text += "\r\n" + text;
        }

        private async Task DownloadFile(Uri target, DirectoryInfo saveTo, string fileName)
        {
            WriteLine($"Downloading {target} to {saveTo}\\{fileName}");

            using (var response = await httpClient.GetAsync(target, HttpCompletionOption.ResponseHeadersRead))
            using (var fileStream = File.Create(saveTo.FullName + "\\" + fileName))
            using (var httpStream = await response.Content.ReadAsStreamAsync())
            {
                httpStream.CopyTo(fileStream);
                fileStream.Flush();
            }

            WriteLine($"Downloaded successfully.");
        }

        private void createShortcut(string shortcutPath, string target)
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
    }
}
