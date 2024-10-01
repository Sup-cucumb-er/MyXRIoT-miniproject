# MyXRIoT-miniproject
The mini project of MyXRIoT is dedicated to make an example of combining Unity, Android app, and OneM2M. The purpose is to show a color ball in the XR world with a command in the android app. The OneM2M standard resource tree will be used for connecting the data between unity and android app. 

## Functions
### Video
<video src="https://youtu.be/tNjy2agyhAs"></video>
### The Unity Scene
![螢幕擷取畫面 2024-01-07 203602](https://github.com/Sup-cucumb-er/Mini-Project-of-myXRIoT/assets/92028905/2c775589-0dd8-4b69-9651-cc489ae2be1e)

> Fig1. The three colors are yellow, blue, and red with the value 1, 2, and 3. If the android app sent value 3, the scene only shows the red ball.

![螢幕擷取畫面 2024-09-12 115354](https://github.com/user-attachments/assets/ab3f73bf-c5c4-4f81-8624-b75c9cc84292)

> Fig2. After the game started, the balls are initially unvisible. The scripts can read the value from OM2M and make a correspond ball be visible.

### The Android app
![螢幕擷取畫面 2024-09-12 115550](https://github.com/user-attachments/assets/e1473ee7-fd3f-4694-9352-d621c0826d30)

> Fig3. First, place your OM2M Server IP address into the IP textbox and press Enter.<br>
     After showing your IP address below, you can type in a value representing the ball color.<br>
     As soon as you send your value, it will be stored inside the OM2M resource tree.<br>

![螢幕擷取畫面 2024-09-12 152122](https://github.com/user-attachments/assets/dfb54590-b727-42ad-9c27-a8fef1802648)

> Fig4. The codeblock of GiveUNITYColor.apk

### OneM2M Resource Tree
![螢幕擷取畫面 2024-09-12 115958](https://github.com/user-attachments/assets/3fc4d0fd-dacb-40fb-a300-5555a14d6370)

> Fig5. The Resource tree records the data that was sent. Here is the MN-CSE resource tree, you can see the Attribute is "Color" and the Value is "3". 



## Installation

1. Via the aid of the aid of notion wensite <https://abounding-monkey-e51.notion.site/OM2M-d07323a8e2c047d88b9ef74c47fd5d77>, you can eventually create your own onem2m website.
2. Building the Node-Red by modifying the example from hackmd website <https://hackmd.io/@p76081514/B1jIllgfP>.
3. If you follow the instructions and modify properly, the OM2M website will be built inside your linux VMware.
4. Install GiveUNITYColor.apk into smartphone simulator
5. Create an empty project in Unity, the ball materials , scripts , and scenes are provided, add them in to the project.

## How to Use

When the user send the value from GiveUNITYColor app, Node-Red in linux VMware post the value to particular container.<br>
Unity HTTP Server is created as well as the subscription to the OM2M container when starting the game.<br>
Unity MainThreadDispatcher set the corresponding color ball in active, the user can observe the color ball appears.<br>

## Certificate

Only personal usage.

## Contact

Please contact me via github.
