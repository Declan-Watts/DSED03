
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using DSED03.Data;
using System;
using System.Collections.Generic;

namespace DSED03
{
    [Activity(Label = "HangManActivity")]
    public class HangManActivity : Activity
    {
        #region Globals
        HangmanGamePlay Game;
        TextView hangmanWelcomeMessage;
        TextView txtWord;
        TextView txtMessage;
        ImageView hangmanImage;
        BottomNavigationView bottomNavigation;
        string name;
        string myPackageName;
        List<Users> activeUser;

        Button[] keys;
        Button restartGameButton;

        #endregion

        #region On Creation and Initialization Methods

        #region onCreate
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.activity_hangman);
            // Getting the name from Welcome page
            name = Intent.GetStringExtra("Name");
            // Initialization
            Init();
        }
        #endregion

        #region Init
        private void Init()
        {
            activeUser = Database.LoadActiveUser();
            // Binding Resouces to variables
            hangmanWelcomeMessage = FindViewById<TextView>(Resource.Id.hangmanWelcomeMessage);
            txtWord = FindViewById<TextView>(Resource.Id.txtWord);
            txtMessage = FindViewById<TextView>(Resource.Id.hangmanMessage);
            hangmanImage = FindViewById<ImageView>(Resource.Id.hangmanImg);
            restartGameButton = FindViewById<Button>(Resource.Id.btnReset);
            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            restartGameButton.Click += restartGameButton_Click;
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            myPackageName = Application.PackageName;
            // Keyboard Initialization
            keyboardInit();
            // Setting Default Values
            setDefaults();
            // Binding Fronend items to variables in the Game Class
            bindFrontEnd();
            // Starting the Game
            startGame();
        }



        #endregion

        #region some more dumb keyboard stuff
        private void keyboardInit()
        {
            // Define Keys
            keys = new Button[26];
            // Define KeyIDs from Resource file
            string keyNames = "QWERTYUIOPASDFGHJKLZXCVBNM";


            // Bind Keys to View using KeyIDs
            for (int i = 0; i < keys.Length; i++)
            {

                //Generating String Name
                string drawableName = $"key{keyNames[i]}";
                // Getting the Resource ID
                int resID = Application.Resources.GetIdentifier(drawableName, "id", myPackageName);
                // Setting the button
                keys[i] = FindViewById<Button>(resID);
                keys[i].Click += Key_Click;
            }
        }
        #endregion


        #region bindFrontEnd
        private void bindFrontEnd()
        {
            // Binding Game properties to the frontend
            Game = new HangmanGamePlay() { displayedWord = txtWord, message = txtMessage };
        }
        #endregion

        #region setDefaults
        private void setDefaults()
        {
            hangmanWelcomeMessage.Text = $"Welcome {name}";
        }
        #endregion

        #region startGame
        private void startGame()
        {
            Game.newGame();
        }
        #endregion

        #endregion

        #region Key Clicks
        private void Key_Click(object sender, EventArgs e)
        {
            Button keyPressed = (Button)sender;
            // Disable Key
            keyPressed.Enabled = false;
            // Pass through keyPressed.Text
            runGuess(keyPressed.Text.ToLower());
            updateImage();
            nextRound();
        }

        private void restartGameButton_Click(object sender, EventArgs e)
        {
            restartGame();
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.Item.ToString())
            {
                case "Leaderboard":
                    var leaderBoardActivity = new Intent(this, typeof(LeaderboardActivity));
                    StartActivity(leaderBoardActivity);
                    Finish();
                    break;
                case "Play":
                    break;
                case "Logout":
                    Database.LogoutActiveUser(activeUser);
                    var loginActivity = new Intent(this, typeof(MainActivity));
                    StartActivity(loginActivity);
                    Finish();
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void runGuess(string guess)
        {
            Game.makeGuess(guess);
        }

        private void updateImage()
        {
            // Generating the name of the next Image
            string drawableName = $"asset{Game.incorrectGuesses}";
            // Getting the Resource ID
            int resID = Application.Resources.GetIdentifier(drawableName, "drawable", myPackageName);
            // Setting the Image
            hangmanImage.SetImageResource(resID);
        }

        private void nextRound()
        {
            if (Game.isFinished())
            {
                disableAllKeys();
                Game.endGame();
            }
        }

        private void disableAllKeys()
        {
            foreach (Button key in keys)
            {
                key.Enabled = false;
            }
        }

        private void enableAllKeys()
        {
            foreach (Button key in keys)
            {
                key.Enabled = true;
            }
        }

        private void restartGame()
        {
            Game.newGame();
            updateImage();
            enableAllKeys();
        }
    }
}