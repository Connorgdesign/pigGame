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
        string PlayerTurn;
        string CurrentPlayer;
        string Score1Text;
        string Score2Text;
        int Score1;
        int Score2;


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
            die = FindViewById<ImageView>(Resource.Id.dieImage);


            newgame = new PigLogic();
           
            if (bundle != null)
            {
                
                Score1 = bundle.GetInt("Score1");
                Score2 = bundle.GetInt("Score2");

                Score1Text = bundle.GetString("Score1Text");
                Score2Text = bundle.GetString("Score2Text");
                CurrentPlayer = bundle.GetString("CurrentPlayer");
                PlayerTurn = bundle.GetString("PlayerTurn");

                newgame.player1Score = Score1;
                newgame.player2Score = Score2;
                
                newgame.playerTurn = PlayerTurn;
                newgame.currentPlayer = CurrentPlayer;
                newgame.player1Score = Score1;
                newgame.player2Score = Score2;

                player1Score.Text = Score1Text;
                player2Score.Text = Score2Text;
                currentPlayer.Text = CurrentPlayer;
                Toast.MakeText(this, PlayerTurn.ToString(), ToastLength.Long).Show();
            }
            else {
                //newgame = new PigLogic();
                newgame.newGame();
                Score1Text = newgame.player1Score.ToString();
                Score2Text = newgame.player2Score.ToString();    
          
            }   

            var newGameButton = FindViewById<Button>(Resource.Id.newGameButton);
            newGameButton.Click += delegate
            {
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
                newgame.currentPlayer = CurrentPlayer;
                newgame.getPlayerTurn();
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
                currentPlayer.Text = newgame.getCurrentPlayer();

            };

            var endTurnButton = FindViewById<Button>(Resource.Id.endTurnButton);
            endTurnButton.Click += delegate
            {
                newgame.getPlayerTurn();

                newgame.endTurn();
                if(newgame.player1Score >= 100)
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
            outState.PutString("Score1Text", player1Score.Text);
            outState.PutString("Score2Text", player2Score.Text);
            outState.PutString("CurrentPlayer", newgame.getCurrentPlayer());
            outState.PutString("PlayerTurn", newgame.getPlayerTurn());

        }
    }
}