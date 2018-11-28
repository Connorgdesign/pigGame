using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace PigGameUi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView die;
        string dieName;
        PigLogic newgame;

        EditText player1;
        EditText player2;
        TextView player1Score;
        TextView player2Score;
        TextView currentScore;
        TextView currentPlayer;

        string CurrentPlayer;
        int Score1;
        int Score2;
        string PlayerTurn;
        int CurrentPoints;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            //get player 1 name from edit text
            player1 = FindViewById<EditText>(Resource.Id.player1EditText);

            //get player 2 from edit text
            player2 = FindViewById<EditText>(Resource.Id.player2EditText);

            //Get player 1 score text field
            player1Score = FindViewById<TextView>(Resource.Id.player1ScoreText);

            //get player 2 score text field
            player2Score = FindViewById<TextView>(Resource.Id.player2ScoreText);

            currentScore = FindViewById<TextView>(Resource.Id.currentPointsText);

            currentPlayer = FindViewById<TextView>(Resource.Id.currentPlayerText);

            
            //Toast.MakeText(this, newgame.player1Score, ToastLength.Long).Show();

            die = FindViewById<ImageView>(Resource.Id.dieImage);
           
            if (bundle != null)
            {
                Score1 = bundle.GetInt("Score1");
                Score2 = bundle.GetInt("Score2");
                CurrentPoints = bundle.GetInt("CurrentPoints");
                CurrentPlayer = bundle.GetString("CurrentPlayer");
                PlayerTurn = bundle.GetString("PlayerTurn");

                

                newgame = new PigLogic(Score1, Score2, PlayerTurn, CurrentPlayer, CurrentPoints);
                newgame.currentPlayer = CurrentPlayer;
                
                currentPlayer.Text = CurrentPlayer;
                ShowPlayer1Score();
                ShowPlayer2Score();
                ShowCurrentScore();
            }
            else {

                newgame = new PigLogic();
                Score1 = newgame.player1Score;
                Score2 = newgame.player2Score;
          
            }   

            var newGameButton = FindViewById<Button>(Resource.Id.newGameButton);
            newGameButton.Click += delegate
            {
                newgame = new PigLogic();
             
                Score1 = newgame.player1Score;
                Score2 = newgame.player2Score;
                newgame.newGame();

                ShowPlayer1Score();
                ShowPlayer2Score();

                newgame.player1Name = player1.Text;
                newgame.player2Name = player2.Text;

                currentPlayer.Text = newgame.getCurrentPlayer();

            };

            var rollDieButton = FindViewById<Button>(Resource.Id.rollDieButton);
            rollDieButton.Click += delegate
            {
                // Score1 = newgame.player1Score;

                
                //currentPlayer.Text = newgame.getPlayerTurn();
               

                currentScore.Text = newgame.RollDie().ToString();

                int roll = newgame.Roll;

              

                if (roll == 8)
                {
                    newgame.endTurn();
                    ShowPlayer1Score();
                    ShowPlayer2Score();
                    ShowCurrentScore();


                    currentPlayer.Text = newgame.getCurrentPlayer();
                }
               
                dieName = "die8side" + roll;
                int x = Resources.GetIdentifier(dieName, "drawable", PackageName);
                die.SetImageResource(x);
                currentPlayer.Text = newgame.currentPlayer;

            };

            var endTurnButton = FindViewById<Button>(Resource.Id.endTurnButton);
            endTurnButton.Click += delegate
            {

          

                newgame.endTurn();

                if (newgame.player1Score >= 100)
                {
                    player1Score.Text = "Winner";
                    player2Score.Text = "Loser";

                    ShowCurrentScore();

                    dieName = "die8side1";
                    int x = Resources.GetIdentifier(dieName, "drawable", PackageName);
                    die.SetImageResource(x);
                }
                else if(newgame.player2Score >= 100)
                {
                    player1Score.Text = "Loser";
                    player2Score.Text = "Winner";
                 
                    ShowCurrentScore();

                    dieName = "die8side1";
                    int x = Resources.GetIdentifier(dieName, "drawable", PackageName);
                    die.SetImageResource(x);
                }
                else {


                    
                    ShowPlayer1Score();
                    ShowPlayer2Score();
                  
                    ShowCurrentScore();
                    

                    dieName = "die8side1";
                    int x = Resources.GetIdentifier(dieName, "drawable", PackageName);
                    die.SetImageResource(x);
                    


                }
                
            };
        }


        private void ShowPlayer1Score()
        {

            player1Score.Text = newgame.player1Score.ToString();
        }

        private void ShowPlayer2Score()
        {
            player2Score.Text = newgame.player2Score.ToString();
        }

        private void ShowCurrentScore()
        {
            currentScore.Text = newgame.currentPoints.ToString();
        }

        private void ShowCurrentPlayer()
        {
            currentPlayer.Text = newgame.getCurrentPlayer();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("Score1", newgame.player1Score);
            outState.PutInt("Score2", newgame.player2Score);
            outState.PutInt("CurrentPoints", newgame.currentPoints);
            outState.PutString("CurrentPlayer", newgame.getCurrentPlayer());
            outState.PutString("PlayerTurn", newgame.getPlayerTurn());

        }
    }
}