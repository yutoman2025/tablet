# ControlScaler クラス  
 `ControlScaler` クラスは、フォームのサイズにあわせてフォーム上のコントロールの位置やサイズの調整を行います。  
 付随する `ControlScalerProvider` クラスは、コントロールの配置を調整するためのプロパティーをデザイナに提供します。

## 使用方法  

### 1. ソースコードのビルド
デザイナで `ControlScalerProvider` コンポーネントを使用するために、まだプロジェクトを一度もビルドしていない場合は、ビルドを実行します。

### 2. フォーム上に ControlScalerProvider を配置
ビルドを実行すると、ツールボックスに `ControlScalerProvider` コンポーネントが追加されます。  
デザイナを開いた状態で、ツールボックスの `ControlScalerProvider` をダブルクリックするか、フォーム上にドラッグ＆ドロップして、このコンポーネントをフォームに追加します。

### 3. クラスのソースコードを修正
① 追加するフォームのソースコードに、 `ControlScaler` のメンバを追加します。  

② フォームのコンストラクタで、 `ControlScaler` クラスの `CaptureInitialState()` メソッドを呼び出します。  
`ControlScaler` のインスタンス内の情報が、デザイナで設定した値で初期化されます。  

③ フォームの `Resize` イベントプロシージャで、 `ControlScaler` クラスの `ScaleToCurrentSize()` メソッドを呼び出します。  
各コントロールの位置やサイズの調整が行われます。

```cs
private ControlScaler scaler;

public Form1()
{
	InitializeComponent();

	// ControlScalerインスタンスの初期化
	scaler = new ControlScaler();      
	scaler.CaptureInitialState(this);
}

private void Form1_Resize(object sender, EventArgs e)
{
	// ControlScalerによるコントロールの調整
	scaler?.ScaleToCurrentSize(this, controlScalerProvider1);
}
```

### 4. 各コントロールの配置プロパティーを調整
デザイナで配置したButtonやLabelなどのコントロールを選択すると、 `Anchor on controlScalerProvider1` などのプロパティーが追加されています。  
プロパティーウィンドウを `項目別` 表示にすると、これらは `ControlScaler` カテゴリに集約されます。

意図した挙動になるように、各プロパティーの設定値を調整します。  
|プロパティー名|型|説明|
|---|---|---|
|Anchor|ControlAnchor|配置変更を行う際のコントロールの基準位置を設定します。<br>通常は `TopLeft` を設定します。<br>フォームの右下に配置されているコントロールは、`BottomRight` に設定することで右側が見切れてしまう現象を防止できます。|
|FontResizable|ControlExpantion|コントロールのサイズ変更に合わせて、フォントサイズを調整するかを設定します。<br> `NotAllow` サイズ変更は行われません。<br> `AllowBoth` 拡大、縮小の両方が行われます。<br> `AllowEnlargementOnly` 拡大のみ行われます。<br> `AllowShrinkingOnly` 縮小のみ行われます。|
|Movable|bool|フォームサイズに合わせて、コントロールの移動を行うかを設定します。|
|RefLocation|Point|コントロールの移動基準点を設定します。<br>通常は、原点(0, 0)に設定します。この場合、コントロールはフォームサイズの変化ベクトルに比例して移動します。<br>基準点をコントロールの `Location` 初期値に近づけると、フォームサイズを変更してもコントロールはほとんど移動しなくなります。|
|ResizableX|ControlExpantion|コントロールのサイズ変更に合わせて、横幅を調整するかを設定します。<br>挙動の変化は `FontResizable` の項目を参照してください。|
|ResizableY|ControlExpantion|コントロールのサイズ変更に合わせて、縦幅を調整するかを設定します。<br>挙動の変化は `FontResizable` の項目を参照してください。|

### 5. その他
・フォームの `AutoSize` プロパティーは `false` に設定してください。  
`true` のままだと、コントロールがフォームサイズの変更を邪魔するため、ウィンドウが一定以上縮小できません。

・すべてのコントロールの `Anchor` プロパティー（配置カテゴリにある標準のもの）は `None` に設定してください。  
`None` 以外に設定されていると、標準機能がコントロールの配置を移動させてしまいます。