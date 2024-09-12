# MyXRIoT-miniproject
The mini project of MyXRIoT is dedicated to make an example of combining Unity, Android app, and OneM2M. The purpose is to show a color ball in the XR world with a command in the android app. The OneM2M standard resource tree will be used for connecting the data between unity and android app. 

## Functions

### The Unity Scene
![螢幕擷取畫面 2024-01-07 203602](https://github.com/Sup-cucumb-er/Mini-Project-of-myXRIoT/assets/92028905/2c775589-0dd8-4b69-9651-cc489ae2be1e)

Fig1. The three colors are yellow, blue, and red with the value 1, 2, and 3. If the android app sent value 1, the scene only shows the yellow ball.

![螢幕擷取畫面 2024-09-12 115354](https://github.com/user-attachments/assets/ab3f73bf-c5c4-4f81-8624-b75c9cc84292)

Fig2. After the game started, the balls are initially unvisible. The scripts can read the value from OM2M and make a correspond ball be visible.

### The Android app
![螢幕擷取畫面 2024-09-12 115550](https://github.com/user-attachments/assets/e1473ee7-fd3f-4694-9352-d621c0826d30)

Fig3. Place your OM2M Server IP address into the IP textbox and creates a repository for your data. After showing your IP address below, you can type in a number representing the ball color. When you send out your newColorValue, it will be stored inside MN-CSE resource tree.

### OneM2M Resource Tree
![螢幕擷取畫面 2024-09-12 115958](https://github.com/user-attachments/assets/3fc4d0fd-dacb-40fb-a300-5555a14d6370)

Fig4. The Resource tree records the data that was sent. Here is the MN-CSE resource tree, you can see the Attribute is "Red" and the Value is "3". 
 When the user send the value from GiveUNITYColor app, Node-Red in linux VMware post the value to particular container. In this case, it is UNITY-->DATA.


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
