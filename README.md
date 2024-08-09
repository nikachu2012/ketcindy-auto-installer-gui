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
<img width="361" alt="image" src="https://github.com/user-attachments/assets/533fae79-22eb-4796-a5dc-3801e5f615cf">

v1.1より、KeTTeXとKeTCindyについて、GitHub APIから最新バージョンを取得することで、常に最新版がダウンロードされるようになりました。  
上記画像のようにバージョンの選択を行うことも可能です。

## 使い方
> [!IMPORTANT]
> 使用しているKeTTeXが Visual C++ 再頒布可能パッケージ を要求するようになったので、事前にhttps://aka.ms/vs/17/release/vc_redist.x64.exe を事前にインストールしたほうが良いかもしれません。

1. 右側のReleasesから最新版をダウンロード
2. ダブルクリックで実行(`Windows によってPCが保護されました`が表示されたら詳細情報→実行の順にクリック )
3. Installボタンをクリック

5. 設定用のCinderellaファイルが開いたら、"Kettex", "Mkinit", "Update", "Work"の順で黄色のボタンをクリック
6. ウィンドウをすべて閉じる

また、デスクトップにC:\ketcindyフォルダへのショートカットができます。

## 更新履歴
[Releases](https://github.com/nikachu2012/ketcindy-auto-installer-gui/releases)をご覧ください。

## p.s.
- .NETで最初作ったけどランタイムインストールが必須って言われたから.NET Frameworkで作りなおした
- バージョンの自動更新には非対応
- Windows Formsについてアドバイスくれた某氏ありがとう
- だれかデジタル署名ください(`Windows によってPCが保護されました`が出なくなる)
  
