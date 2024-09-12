# MyXRIoT-miniproject
The mini project of MyXRIoT is dedicated to make an example of combining Unity, Android app, and OneM2M. The purpose is to show a color ball in the XR world with a command in the android app. The OneM2M standard resource tree will be used for connecting the data between unity and android app. 

## Functions

### The Unity Scene
![螢幕擷取畫面 2024-01-07 203602](https://github.com/Sup-cucumb-er/Mini-Project-of-myXRIoT/assets/92028905/2c775589-0dd8-4b69-9651-cc489ae2be1e)
The three colors are yellow, blue, and red with the value 1, 2, and 3. If the android app says 1, the scene shows only the yellow ball.
### The Android app
![螢幕擷取畫面 2024-01-07 213221](https://github.com/Sup-cucumb-er/Mini-Project-of-myXRIoT/assets/92028905/a22dd24d-ad2c-4a96-9b56-bbb98531f6d1)
Putting your IP address into the IP textbox will tells OneM2M where you are and creates a repository for your data. After showing your IP address below, you can type in a number representing the ball color. When you send out your newColorValue, it will be stored inside MN-CSE resource tree.
### OneM2M Resource Tree
![螢幕擷取畫面 2024-01-07 212943](https://github.com/Sup-cucumb-er/Mini-Project-of-myXRIoT/assets/92028905/2b2f8b0e-02de-42d1-ab0d-55753de76c52)
The Resource tree records the data that was sent. Here is the MN-CSE resource tree, you can see the Attribute is "Red" and the Value is "3". 

## Installation

Via the aid of the aid of notion wensite (https://abounding-monkey-e51.notion.site/OM2M-d07323a8e2c047d88b9ef74c47fd5d77) , you can eventually create your own onem2m website.

```
代碼示例（如果適用）
```

## 使用方法

提供使用您項目的簡單示例。

## 貢獻

說明其他人如何為您的項目做出貢獻。

## 許可證

說明您的項目使用的許可證。

## 聯繫方式

提供您的聯繫信息或項目相關的聯繫方式。
