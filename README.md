[English version](#en) is at the end.

# KeTCindyAutoInstallerGUI

以下のソフトウェアを自動でインストールし、KeTCindyを使えるようにするソフトウェアです。
.NET Framework 4.7.2が必要です。

  - Cinderella2
  - KeTTeX
  - R
  - SumatraPDF
  - Maxima
  - KeTCindy

## 最新バージョンでの更新点

v1.1より、KeTTeXとKeTCindyについて、GitHub APIから最新バージョンを取得することで、常に最新版がダウンロードされるようになりました。  
上記画像のようにバージョンの選択を行うことも可能です。

v1.6より、Cinderella2、R、Maximaについても公式サイトのHTMLを解析することで、常に最新版がダウンロードされるようになりました。
最新版と、動作確認を行ったバージョンの2つを選ぶことができます。

## 使い方

1.  右側のReleasesから最新版をダウンロード
2.  ダブルクリックで実行(`Windows によってPCが保護されました`が表示されたら詳細情報→実行の順にクリック )
3.  Installボタンをクリック

> [\!IMPORTANT]
> KeTTeXのインストール中に"続行するには何かキーを押してください . . ."が表示されたら任意のキーを押さないと続行しないので注意

5.  設定用のCinderellaファイルが開いたら、`Kettex`, `Mkinit`, `Update`, `Work`の順で黄色のボタンをクリック
6.  ウィンドウをすべて閉じる

> [\!TIP]
>   
> KeTTeXのインストール中、コマンドプロンプトをクリックしてしまうと文字が選択されてしまい、それ以上処理がが進まなくなります。
> このようになった場合はウィンドウのどこかをクリックした後、Enterを押して解除するようにしてください。

また、デスクトップにC:\\ketcindyフォルダへのショートカットができます。

## 更新履歴

[Releases](https://www.google.com/search?q=https://github.com/nikachu2012/ketcindy-auto-installer-gui/releases)をご覧ください。

## p.s.

  - .NETで最初作ったけどランタイムインストールが必須って言われたから.NET Frameworkで作りなおした
  - バージョンの自動更新には非対応
  - Windows Formsについてアドバイスくれた某氏ありがとう
  - だれかデジタル署名ください(`Windows によってPCが保護されました`が出なくなる)
  - 某高専の某先生利用報告ありがとうございます。開発の励みになります。

-----

<a name="en"></a>

# KeTCindyAutoInstallerGUI (English Translation)

This software automatically installs the following software to enable the use of KeTCindy.
Requires .NET Framework 4.7.2.

  - Cinderella2
  - KeTTeX
  - R
  - SumatraPDF
  - Maxima
  - KeTCindy

## What's new in the latest version

From v1.1, the latest versions of KeTTeX and KeTCindy are always downloaded by retrieving the latest version information from the GitHub API.
It is also possible to select a version as shown in the image above.

From v1.6, the latest versions of Cinderella2, R, and Maxima are also always downloaded by parsing the HTML of their official websites.
You can choose between the latest version and a version that has been confirmed to work.

## How to use

1.  Download the latest version from Releases on the right.
2.  Run by double-clicking (if `Windows protected your PC` is displayed, click `More info` → `Run anyway`).
3.  Click the Install button.

> [\!IMPORTANT]
> During the KeTTeX installation, note that it will not proceed unless you press a key when "Press any key to continue . . ." is displayed.

5.  When the Cinderella settings file opens, click the yellow buttons in the order of `Kettex`, `Mkinit`, `Update`, `Work`.
6.  Close all windows.

> [\!TIP]
>   
> If you click on the command prompt during the KeTTeX installation, text will be selected, and the process will halt.
> If this happens, click somewhere else in the window and then press Enter to deselect it.

A shortcut to the C:\\ketcindy folder will also be created on your desktop.

## Update History

Please see the [Releases](https://www.google.com/search?q=https://github.com/nikachu2012/ketcindy-auto-installer-gui/releases).
