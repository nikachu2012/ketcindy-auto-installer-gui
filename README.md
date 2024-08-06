# KeTCindyAutoInstallerGUI
以下のソフトウェアを自動でインストールし、KeTCindyを使えるようにするソフトウェアです。
.NET Framework 4.7.2が必要です。

- Cinderella2
- KeTTeX
- R
- SumatraPDF
- Maxima
- KeTCindy

## 使い方
> [!IMPORTANT]
> 使用しているKeTTeXが Visual C++ 再頒布可能パッケージ を要求するようになったので、事前にhttps://aka.ms/vs/17/release/vc_redist.x64.exe を事前にインストールしたほうが良いかもしれません。

1. 右側のReleasesから最新版をダウンロード
2. exeファイルを管理者として実行する(UACによるダイアログが出るはず)
3. Installボタンをクリックする
4. 設定用のCinderellaファイルが開いたら、"Kettex", "Mkinit", "Update", "Work"の順で黄色のボタンをクリック
5. ウィンドウをすべて閉じる

また、デスクトップにC:\ketcindyフォルダへのショートカットができます。

## p.s.
- .NETで最初作ったけどランタイムインストールが必須って言われたから.NET Frameworkで作りなおした。
- バージョンの自動更新には非対応
- Windows Formsについてアドバイスくれた某氏ありがとう
  
