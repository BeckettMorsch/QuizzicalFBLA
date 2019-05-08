using QuizzicalFBLA.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            BackgroundImage = "Background.png";

            SetupWebView();
        }

        public void SetupWebView ()
        {
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"
<html>
<head>
<style type=""text/css"">
body {
    font-family: Arial, Helvetica, sans-serif;
	color: white;
	background: #3B4051;
}

blockquote {
    border-left: solid 3px lightblue;
    padding-left: 20px;
	padding-top: 5px;
    padding-bottom: 5px;	
}

/* unvisited link */
a:link {
  color: #26c6cc;
}

/* visited link */
a:visited {
  color: #26c6cc;
}

/* mouse over link */
a:hover {
  color: #26c6cc;
}

/* selected link */
a:active {
  color: #26c6cc;
}

h1 {
  font-size: 25px;
  font-weight: bold;
  color: #B0C4DE;
  border-bottom: 2px solid #7cfb97;
  display: inline-block;
}

h2 {
    margin-top: 40px;
  font-size: 20px;
  font-weight: bold;
  color: #B0C4DE;
  border-bottom: 2px solid #7cfb97;
  display: inline-block;
}

h3 {
    margin-top: 40px;
  font-size: 18px;
  font-weight: bold;
  color: #B0C4DE;
  border-bottom: 2px solid #7cfb97;
  display: inline-block;
}

h4 {
    margin-top: 40px;
  font-size: 16px;
  font-weight: bold;
  color: #B0C4DE;
  border-bottom: 2px solid #7cfb97;
  display: inline-block;
}

p {
  font-size: 14px;
}
</style>
</head>
<body>
<h1 id=""quizzical-fbla-1-0-readme"">Quizzical FBLA 1.0</h1>
<p>by Anthony Gonella, Beckett Morsch, Matthew Smickle</p>
<p>QuizzicalFBLA is a mobile application developed for IOS and Android phones. This app tests the users FBLA knowledge by asking them questions on a wide range of FBLA  subjects.  At the end of the quiz the user can even <strong>share their results on multiple social  media platforms</strong> such as Facebook, Twitter, Reddit.   In fact, you can share results on any social platform supported by the mobile device.  QuizzicalFBLA is bug free and features a  fully functional bug reporting system if a user encounters an issue.  It also features crash and error reporting to the centralized Microsoft App Center along with valuable usage analytics.  Social logins from Facebook and Gmail are fully supported!</p>
<p><img src=""https://raw.githubusercontent.com/BeckettMorsch/QuizzicalFBLA/master/Media/auth0.png"" alt=""""></p>
<h2 id=""features"">Features</h2>
<ul>
<li>Designed for Android, iOS, and UWP - We support all three platforms</li>
<li>Facebook and Gmail social login support for quick account creation</li>
<li>Custom account creation if you want to create a new account with just your email address</li>
<li>Over 100 questions in 5 quiz categories! </li>
<li>Make sure you answer quickly with only 30 seconds to complete questions</li>
<li>Quizzes are generated randomly from our massive pool of questions</li>
<li>Swipe through our intuitive flashcards that allow you to study all our questions or drill down to specific categories</li>
<li>Leaderboard shows the top users who have accumulated the most points playing</li>
<li>Cloud-based user account storage allows you to use the app on any device seamlessly</li>
<li>Found a bug?  Report any bugs along with screen captures and videos directly to us</li>
</ul>

<h2 id=""other-notes"">Other Notes</h2>
<ul>
<li>All of the code that is contained within QuizzicalFBLA is error free and can be run with no issues.  </li>
<li>QuizzicalFBLA is entirely written in C# using the Xamarin Framework.</li>
<li>The navigation between pages is also error free and all of the buttons on the app take the user to the intended pages.</li>
<li>The QuizzicalFBLA app is compatible with Windows, Android, and IOS phones and tablets.</li>
<li>The questions in the app all pertain to the topic FBLA</li>
</ul>
<h2 id=""resources-used"">Resources Used</h2>
<h3 id=""media-assets"">Media Assets</h3>
<h4 id=""google-material-design-icons"">Google Material Design Icons</h4>
<p>Copyright 2019 Google</p>
<p>Licensed under the Apache License, Version 2.0 (the &quot;License&quot;); you may not use this file except in compliance with the License. You may obtain a copy of the License at</p>
<p><a href=""http://www.apache.org/licenses/LICENSE-2.0"">http://www.apache.org/licenses/LICENSE-2.0</a></p>
<p>Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an &quot;AS IS&quot; BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
<br/><br/>                                        </p>
<h4 id=""sound-effects-obtained-via-creative-commons-attribution-license"">Sound Effects Obtained via Creative Commons Attribution License</h4>
<p>negative_beeps.wav by themusicalnomad</p>
<blockquote>
<p><a href=""https://freesound.org/people/themusicalnomad/sounds/253886/"">https://freesound.org/people/themusicalnomad/sounds/253886/</a></p>
</blockquote>
<p>ultradust_clock.wav by ultradust </p>
<blockquote>
<p><a href=""https://freesound.org/people/ultradust/sounds/167385/"">https://freesound.org/people/ultradust/sounds/167385/</a></p>
</blockquote>
<p>error.wav by distillerystudio </p>
<blockquote>
<p><a href=""https://freesound.org/people/distillerystudio/sounds/327737/"">https://freesound.org/people/distillerystudio/sounds/327737/</a></p>
</blockquote>
<p>incorrect.wav by bertrof </p>
<blockquote>
<p><a href=""https://freesound.org/people/Bertrof/sounds/351565/"">https://freesound.org/people/Bertrof/sounds/351565/</a></p>
</blockquote>
<p>correct.wav by bertrof </p>
<blockquote>
<p><a href=""https://freesound.org/people/Bertrof/sounds/351566/"">https://freesound.org/people/Bertrof/sounds/351566/</a></p>
</blockquote>
<p><br/><br/>                       </p>
<h4 id=""additional-sound-effects-from-https-www-zapsplat-com-https-www-zapsplat-com-"">Additional sound effects from <a href=""https://www.zapsplat.com"">https://www.zapsplat.com</a></h4>
<h3 id=""lottie-animations-obtained-from-lottiefiles-com"">Lottie Animations obtained from LottieFiles.com</h3>
<p>Lottie animatons were not altered in any way and obtained via Creative Commons Attribution License
<a href=""https://creativecommons.org/licenses/by/4.0/"">https://creativecommons.org/licenses/by/4.0/</a></p>
<p>&quot;Checked Done&quot; by LottieFiles - <a href=""https://lottiefiles.com/433-checked-done"">https://lottiefiles.com/433-checked-done</a></p>
<p>&quot;Wrong Answer&quot; by Pedro Silva -<a href=""https://lottiefiles.com/4698-wrong-answer"">https://lottiefiles.com/4698-wrong-answer</a></p>
<p>&quot;Material Loader&quot; by LottieFiles - <a href=""https://lottiefiles.com/50-material-loader"">https://lottiefiles.com/50-material-loader</a></p>
<p>&quot;AashishDeleteAnimation&quot; by Aashish Soam - <a href=""https://lottiefiles.com/5474-aashishdeleteanimation"">https://lottiefiles.com/5474-aashishdeleteanimation</a></p>
<p>&quot;Trophy&quot; by Lucas Nemo - <a href=""https://lottiefiles.com/677-trophy"">https://lottiefiles.com/677-trophy</a><br><br/><br/></p>
<h2 id=""software-and-services-used"">Software and Services Used</h2>
<p>Quizzical FBLA was developed using the following software applications and services: </p>
<p>Auth0 - <a href=""https://www.auth0.com"">https://www.auth0.com</a></p>
<blockquote>
<p>Purpose: Auth0 provides a universal authentication &amp; authorization platform for web, mobile and legacy applications.  You can easily and quickly connect your apps, choose identity providers, add users, set up rules, customize your login page and access analytics from one dashboard</p>
</blockquote>
<p>GameSparks - <a href=""https://www.gamesparks.com/"">https://www.gamesparks.com/</a></p>
<blockquote>
<p>Purpose: GameSparks is a cloud-based solution for game developers that helps them to build their server-side components without ever having to set up and run a server.  We used GameSparks for storage of user accounts and score tracking.</p>
</blockquote>
<p>Github - <a href=""https://github.com/"">https://github.com/</a> </p>
<blockquote>
<p>Purpose: Github is an online source hosting service based around the Git version control system.  We utilized Github to store source code revisions during this project. </p>
</blockquote>
<p>Gitkraken - <a href=""https://www.gitkraken.com/"">https://www.gitkraken.com/</a></p>
<blockquote>
<p>Purpose:  Gitkraken was utilized to manage code revisions, resolve merge conflicts, and test experimental branch features. </p>
</blockquote>
<p>Instabug - <a href=""https://instabug.com/"">https://instabug.com/</a> </p>
<blockquote>
<p>Purpose:  We utilize Instabug to provide comprehensive bug reporting and in-app feedback from our users during beta testing.   Instabug automatically attaches steps to reproduce a bug, network request logs and view hierarchy inspections with each bug report.  It also allows users to record videos demonstrating their problem. </p>
</blockquote>
<p>Microsoft App Center - <a href=""http://appcenter.ms"">http://appcenter.ms</a> </p>
<blockquote>
<p>Purpose:  Captures analytics information to allow us to learn Quizzical usage patterns as well as logs information about application crashes and any generated exception errors. </p>
</blockquote>
<p>Microsoft Visual Studio 2017 </p>
<blockquote>
<p>Purpose:  IDE for developing Xamarin.Forms applications in C# </p>
</blockquote>
<p>Photopea <a href=""https://www.photopea.com/"">https://www.photopea.com/</a> </p>
<blockquote>
<p>Purpose:  Photopea is an online graphics editor that is similar to Adobe Photoshop. We used Photopea to manipulate all of our graphics. 
<br/><br/></p>
</blockquote>
<h2 id=""additional-software-components"">Additional Software Components</h2>
<p>The following software components are also part of the QuizzicalFBLA app: </p>
<p>Chaase.GameSparks.NET - <a href=""https://christianhaase.github.io/Chaase.GameSparks.NET/"">https://christianhaase.github.io/Chaase.GameSparks.NET/</a></p>
<blockquote>
<p>GameSparks.NET is an API wrapper for GameSparks REST API. This package was made with the purpose of making GameSparks integrations with web application, easier for the developer. Instead of having to write your own HTTP requests, GameSparks.NET does the job for you, providing you with easy to use services, classes, and settings. This API wrapper has support for synchronous as well as asycnhronous actions.</p>
</blockquote>
<p>Com.Airbnb.Xamarin.Forms.Lottie by Martijn van Dijk - <a href=""https://www.nuget.org/packages/Com.Airbnb.Xamarin.Forms.Lottie/"">https://www.nuget.org/packages/Com.Airbnb.Xamarin.Forms.Lottie/</a></p>
<blockquote>
<p>Render After Effects animations natively on Android, iOS, MacOS, TVOs and UWP</p>
</blockquote>
<p>Newtonsoft.Json by James Newton-King - <a href=""https://www.nuget.org/packages/Newtonsoft.Json/"">https://www.nuget.org/packages/Newtonsoft.Json/</a></p>
<blockquote>
<p>Json.NET is a popular high-performance JSON framework for .NET</p>
</blockquote>
<p>Xam.Plugin.SimpleAudioPlayer by Adrian Stevens - <a href=""https://www.nuget.org/packages/Xam.Plugin.SimpleAudioPlayer/"">https://www.nuget.org/packages/Xam.Plugin.SimpleAudioPlayer/</a></p>
<blockquote>
<p>A light-weight and easy to use cross-platform audio player for Windows UWP/WPF, Xamarin.iOS, Xamarin.Android, Xamarin.Mac, Xamarin.tvOS, Tizen and Xamarin.Forms. Load wav and mp3 files from any location including a shared library. Works well for sound effects or music. Multiple instances can be instantiated to play multiple sources simultaniously.</p>
</blockquote>
<p>Xamarin.Essentials by Microsoft - <a href=""https://www.nuget.org/packages/Xamarin.Essentials/"">https://www.nuget.org/packages/Xamarin.Essentials/</a></p>
<blockquote>
<p>Xamarin.Essentials: a kit of essential API&#39;s for your apps</p>
</blockquote>
<p>Xamarin.Forms.PancakeView by Steven Thewissen - <a href=""https://www.nuget.org/packages/Xamarin.Forms.PancakeView/"">https://www.nuget.org/packages/Xamarin.Forms.PancakeView/</a></p>
<blockquote>
<p>An extended ContentView for Xamarin.Forms with rounded corners, borders, shadows and more!
<br/><br/></p>
</blockquote>
<h2 id=""references"">References</h2>
<ul>
<li>Shuhaiber, Salam. “FBLA.” <em>Quizlet</em>, 4 Nov. 2018, quizlet.com/334797739/fbla-flash-cards/. </li>
<li>Caminneci, Vincent G. “History of FBLA.” <em>Quizlet</em>, 2015, quizlet.com/332814945/history-of-fbla-flash-cards/. </li>
<li>“FBLA-PBL.” <em>FBLA-PBL</em>, www.fbla-pbl.org/. </li>
<li>“Business Skills for Life-Midterm.” <em>Quizlet</em>, 14 June 2017, quizlet.com/229744801/business-skills-for-life-midterm-flash-cards/. </li>
<li>“Terms &amp; Conditions for Mobile Apps.” <em>TermsFeed</em>, 12 Nov. 2018, termsfeed.com/blog/terms-conditions-mobile-apps/. </li>
<li>“Sample Terms and Conditions Template.” <em>TermsFeed</em>, 30 Nov. 2018, termsfeed.com/blog/sample-terms-and-conditions-template/. </li>
<li>Dearie, KJ, and Zachary Paruch. “Mobile App Terms &amp; Conditions Template &amp; Writing Guide.” <em>Termly</em>, 28 Nov. 2018, termly.io/resources/templates/mobile-app-terms-and-conditions-template/. 
<br/><br/></li>
</ul>
<h2 id=""license"">License</h2>
<p>The MIT License (MIT)</p>
<p>Copyright (c) 2019</p>
<p>Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the &quot;Software&quot;), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:</p>
<p>The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.</p>
<p>THE SOFTWARE IS PROVIDED &quot;AS IS&quot;, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.</p>
</body>
</html>
                                                                                        ";
            webView.Source = htmlSource;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}