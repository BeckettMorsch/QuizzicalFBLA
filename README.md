# Quizzical FBLA 1.0 README
by Anthony Gonella, Beckett Morsch, Mathew Smickle

QuizzicalFBLA is a mobile application developed for IOS and Android phones. This app tests the users FBLA knowledge by asking them questions on a wide range of FBLA  subjects.  At the end of the quiz the user can even share their results on multiple social  media platforms such as Facebook, Twitter, Reddit.   In fact, you can share results on any social platform supported by the mobile device.  QuizzicalFBLA is bug free and features a  fully functional bug reporting system if a user encouters an issue.  It also features crash and error reporting to the centralized Microsoft App Center along with valuable usage analytics.


## Folder Layout
------------------------------------------------------------------------------------------

**/CompiledApp**
> Contains our compiled, signed app in APK form for Android platforms

**/Documentation**
> Contains PDF overview of the app along with screenshots and explanations of all functionality

**/Source**
> Contains Visual Studio 2017 solution file (NOTE: Requires Cross-Platform Visual Studio 2017 Addon)


## How to Run
------------------------------------------------------------------------------------------

This mobile application was developed in C# using Visual Studio 2017 and the Xamarin 
Platform on both Microsoft Windows and OSX.   Contained within the competition submission 
is a folder named “CompiledApp” that contains a signed APK that was created for Android 
phones and emulators. Simply install the APK to your Android mobile device and run.

Please note that because the Windows Phone platform has been discontinued by Microsoft, 
it would be inaccurate to judge our entry based off of strictly running the UWP version 
of the app. Certain features such as bug reporting are only available on Android and iOS 
systems.


## Build Instructions
------------------------------------------------------------------------------------------

Visual Studio Requirements:
- Visual Studio 2017 (Windows or Mac) Community Edition
- Cross-Platform Add-on
- (If Mac) XCode
- Android Platform 27 SDK

***NOTE: API Keys cannot be publicly distributed and are not included on Github - Building this app requires the file Secrets.cs which will be placed in /Source/QuizzicalFBLA/QuizzicalFBLA/Config/***

In order to build for IOS you will need OSX with both XCode and Visual Studio for Mac fully  updated and an Internet connection. Upon opening the Visual Studio solution it will immediately download all necessary packages from Nuget. You will need to execute a debug version of the QuizzicalFBLA.iOS project using the iPhone Simulator.   We recommend utilizing the iPhone XS Max iOS 12.1 simulator.

In order to build for Android you will need Visual Studio or Visual Studio for Mac. Upon opening the Visual Studio solution it will immediately download all necessary packages from Nuget. You will need to execute a debug version of the QuizzicalFBLA.Android project either on a simulator or by connecting an Android mobile device that has Developer Options and Enable USB debugging turned on.   

Enjoy!


## Resources Used

### Media Assets

**Google Material Design Icons**
                                        
Copyright 2019 Google

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
                                        
**Sound Effects Obtained from freesound.org via Creative Commons Attribution License**
                                        
negative_beeps.wav by themusicalnomad
> [https://freesound.org/people/themusicalnomad/sounds/253886/](https://freesound.org/people/themusicalnomad/sounds/253886/)

ultradust_clock.wav by ultradust 
> [https://freesound.org/people/ultradust/sounds/167385/](https://freesound.org/people/ultradust/sounds/167385/)

error.wav by distillerystudio 
> [https://freesound.org/people/distillerystudio/sounds/327737/](https://freesound.org/people/distillerystudio/sounds/327737/)

incorrect.wav by bertrof 
> [https://freesound.org/people/Bertrof/sounds/351565/](https://freesound.org/people/Bertrof/sounds/351565/)

correct.wav by bertrof 
> [https://freesound.org/people/Bertrof/sounds/351566/](https://freesound.org/people/Bertrof/sounds/351566/)

                       
**Additional sound effects from [https://www.zapsplat.com](https://www.zapsplat.com)**
