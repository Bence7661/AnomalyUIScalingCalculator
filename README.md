# Anomaly UI Scaling Calculator
A very very basic tool, to help with precise Anomaly UI work. Based on `utils_xml.script`.

When I first started messing around with UI stuff I quickly realised that it's not as simple as  
**"_I want something to appear at `x: 500 y:400`, so let's set the coordinates to that. Huh? Why is it in a completely different place?_"**  
After like a day of trial and error I realized that the game is not actually rendered in 1920 x 1080, but rather it's upscaled to this resolution, thus why the coordinates didn't exactly work.

I found some information about how the real positions are calculated in `utils_xml.script` and made a basic calculator for myself based off of these findings and I decided to share it, because why not?
I'm also making it open source so you can do whatever you want to with it.  

What really would be cool is to make an actual UI editor program or a VS extension so you can "_drag & drop_" stuff and with the press of a button an `.xml` is generated that is either ready to go or requires minimal adjustments.

# Disclaimer
Now since this is an unsigned `WPF .exe application` Windows Defender will treat it as a virus.  
Use VirusTotal or look online for a trusted virus scanning site/app and check for yourself.  
Since this is open source you don't need to download the `.exe` file. You can download the source code and just compile it yourself.  

Here is the check I made: [VirusTotal check](https://www.virustotal.com/gui/file/7211c7f3b88a211906fd7d2ea36178e4ae1b903145916d2c4ed3849edea6d8bd?nocache=1)

# How to use
I'm gonna show how I do UI and how I use this calculator on a W.I.P. project of mine.  
Let's say I want to put this "Back" button right under the "Repair" button.  
  
![image](https://github.com/user-attachments/assets/64d50079-836c-45f8-8b8b-bbcdd823d6c5)  
  
Here's the relevant part from my `ui_xxx_16.xml`  
```xml
<btn_back x="0" y="0" width="177" height="37">
  <text r="150" g="150" b="150" font="letterica16" align="c" vert_align="c">ui_mm_back</text>
  <texture>ui_button_ordinary</texture>
</btn_back>
```
  
1. I take a screenshot as is and paste it into GIMP (or any other iamge editor).
2. I create a copy of the button and place it where I want it to be.
   
![image](https://github.com/user-attachments/assets/adbf2835-cf0d-4faa-8e80-5ef3dae4b643)  
3. Now I move my cursor to the top left of the button and note down the `X, Y` coordinates which are roughly `X: 570 Y: 890`.
4. I take these and input them in the calculator and press `Calculate` then copy the values. (You can either click one of the values to copy only that or "**_Copy XML Paste Ready_**")
   
![image](https://github.com/user-attachments/assets/3ac1b5a6-2cb6-4867-b9e0-f90fae261a47)

5. Now I just highlight the 2 coordinates paste and save.  
```xml
<btn_back x="304" y="633" width="177" height="37">
  <text r="150" g="150" b="150" font="letterica16" align="c" vert_align="c">ui_mm_back</text>
  <texture>ui_button_ordinary</texture>
</btn_back>
```  
6. Next I refresh my game so the newly modified `.xml` is loaded in.    
This can be done by (debug mode on) Pressing F7 then clicking `Reload system_ini` and then `Refresh game`.
  
![image](https://github.com/user-attachments/assets/959bf746-c0fe-422e-b5d8-e04154b8aef5)

7. After this check again and the button should be exactly where you wanted it to be.

![image](https://github.com/user-attachments/assets/04046c32-e0bb-44cd-a1a3-7c304764f656)
