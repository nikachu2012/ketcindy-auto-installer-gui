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
![image](https://github.com/user-attachments/assets/db1351ea-23c5-4aea-b239-56b463374a8e)

v1.1より、KeTTeXとKeTCindyについて、GitHub APIから最新バージョンを取得することで、常に最新版がダウンロードされるようになりました。  
上記画像のようにバージョンの選択を行うことも可能です。

v1.6より、Cinderella2、R、SumatraPDF、Maximaについても公式サイトのHTMLを解析することで、常に最新版がダウンロードされるようになりました。
最新版と、動作確認を行ったバージョンの2つを選ぶことができます。

## 使い方

1. 右側のReleasesから最新版をダウンロード
2. ダブルクリックで実行(`Windows によってPCが保護されました`が表示されたら詳細情報→実行の順にクリック )
3. Installボタンをクリック

> [!IMPORTANT]
> KeTTeXのインストール中に"続行するには何かキーを押してください . . ."が表示されたら任意のキーを押さないと続行しないので注意
5. 設定用のCinderellaファイルが開いたら、`Kettex`, `Mkinit`, `Update`, `Work`の順で黄色のボタンをクリック
6. ウィンドウをすべて閉じる

> [!TIP]
> ![image](https://github.com/user-attachments/assets/5f8858a2-7d70-4bff-8a12-612d8930797e)  
> KeTTeXのインストール中、コマンドプロンプトをクリックしてしまうと文字が選択されてしまい、それ以上処理がが進まなくなります。
> このようになった場合はウィンドウのどこかをクリックした後、Enterを押して解除するようにしてください。

また、デスクトップにC:\ketcindyフォルダへのショートカットができます。

## 更新履歴
[Releases](https://github.com/nikachu2012/ketcindy-auto-installer-gui/releases)をご覧ください。

## p.s.
- .NETで最初作ったけどランタイムインストールが必須って言われたから.NET Frameworkで作りなおした
- バージョンの自動更新には非対応
- Windows Formsについてアドバイスくれた某氏ありがとう
- だれかデジタル署名ください(`Windows によってPCが保護されました`が出なくなる)
- 某高専の某先生利用報告ありがとうございます。開発の励みになります。
