using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using DSED03.business;
using DSED03.Data;
using System.Collections.Generic;

namespace DSED03
{
    [Activity(Label = "LeaderboardActivity")]
    public class LeaderboardActivity : Activity
    {
        BottomNavigationView bottomNavigation;
        private ListView leaderboardList;
        private List<Users> userList;
        private TextView profileHeader;
        private TextView wins;
        private TextView losses;
        private TextView score;
        private List<Users> activeUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_leaderboard);
            // Set our view from the "main" layout resource
            Init();
        }

        private void Init()
        {
            activeUser = Database.LoadActiveUser();
            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.navigationLeaderboard);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            leaderboardList = FindViewById<ListView>(Resource.Id.leaderboardList);

            profileHeader = FindViewById<TextView>(Resource.Id.profileWelcomeMessage);
            profileHeader.Text = $"{activeUser[0].username}'s Profile";
            wins = FindViewById<TextView>(Resource.Id.profileWins);
            wins.Text = $"{activeUser[0].wins}";
            losses = FindViewById<TextView>(Resource.Id.profileLosses);
            losses.Text = $"{activeUser[0].loses}";
            score = FindViewById<TextView>(Resource.Id.profileScore);
            score.Text = $"{activeUser[0].score}";
            userList = Database.LoadUsers();
            var dataAdapter = new LeaderboardDataAdapter(this, userList);
            leaderboardList.Adapter = dataAdapter;


        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.Item.ToString())
            {
                case "Leaderboard":
                    break;
                case "Play":
                    var hangManActivity = new Intent(this, typeof(HangManActivity));
                    StartActivity(hangManActivity);
                    Finish();
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

    }
}