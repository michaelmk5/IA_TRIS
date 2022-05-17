using System.Collections;

namespace Tris_graf
{
    public partial class TRIS : Form
    {
        int mossa = 1; //Numero mossa del pc
        int match;
        List<string> segni;
        int match_const;
        bool p;
        

        //Creazione Lista combinazioni vincenti
        List<int[]> combo_vincenti = new List<int[]>()
            {
                new int[] {0,1,2}, //Riga 1
                new int[] {3,4,5}, //Riga 2
                new int[] {6,7,8}, //Riga 3
                new int[] {0,3,6}, //Colonna 1
                new int[] {1,4,7}, //Colonna 2
                new int[] {2,5,8}, //Colonna 3
                new int[] {0,4,8}, //Diagonale SX-su
                new int[] {2,4,6}, //Diagonale DX-su
            };
        //Fine creazione


        public TRIS(int partite)
        {

            InitializeComponent();
            lb_turno.Text = Turno(0);
            this.segni = NextMatch();
            this.match = partite;
            this.match_const = partite;
            lb_match.Text = "" + match;
        }
        //Classe mossa
        class Move
        {
            public int row, col;
        };
        static int turno = 0; 
        int click = 0;
        string ris = "";


        //Funzione per calcolare solo le combinazioni vincenti
        

        private string Turno(int turno)
        {
            string giocatore = "";
            if (turno == 0)
                giocatore = "Player 1";
            else
                giocatore = "PC";
            return giocatore;
        }

        //Funzione verifica punteggio giocatore (2su3 - 3su5)
        private void VerificaPunteggio()
        {
            int punti1 = int.Parse(lb_vx.Text);
            int punti2 = int.Parse(lb_vo.Text);
            switch (match_const)
            {
                case 1:
                    {
                        if (punti1 == 1)
                        {
                            match = 0;
                            lb_finale.Text = "Il giocatore 1 ha vinto!!";
                            lb_finale.Visible = true;
                        }
                        else if (punti2 == 1)
                        {
                            match = 0;
                            lb_finale.Text = "Il giocatore 2 ha vinto!!";
                            lb_finale.Visible = true;
                        }
                        break;
                    }
                case 3:
                    {
                        if(punti1 == 2)
                        {
                            match = 0;
                            lb_finale.Text = "Il giocatore 1 ha vinto!!";
                            lb_finale.Visible = true;
                        }else if(punti2 == 2)
                        {
                            match = 0;
                            lb_finale.Text = "Il giocatore 2 ha vinto!!";
                            lb_finale.Visible = true;
                        }
                        break;
                    }
                case 5:
                    {
                        if (punti1 == 3)
                        {
                            match = 0;
                            lb_finale.Text = "Il giocatore 1 ha vinto!!";
                            lb_finale.Visible = true;
                        }
                        else if (punti2 == 3)
                        {
                            match = 0;
                            lb_finale.Text = "Il giocatore 2 ha vinto!!";
                            lb_finale.Visible = true;
                        }
                        break;
                    }
            }
        }
        
        //Funzione incremento punteggio giocatore
        public int Vinte(List<string> segni)
        {
            int vinte = 0;
            int x = int.Parse(lb_vx.Text);
            int o = int.Parse(lb_vo.Text);
            if (VerificaVincita(caselle) == 10)
            {
                x++;
                lb_vx.Text = "" + x;
            }
            else if (VerificaVincita(caselle) == -10)
            {
                o++;
                lb_vo.Text = "" + o;
            }
            return vinte;
        }

        //Funzione inizio nuova partita
        private List<string> NextMatch()
        {
            List<string> segni = new List<string> { "", "", "", "", "", "", "", "", "" };
            var c = Comandi.getAll(this, typeof(Button));
            click = 0;
            btn00.Text = " ";
            btn01.Text = " ";
            btn02.Text = " ";
            btn10.Text = " ";
            btn11.Text = " ";
            btn12.Text = " ";
            btn20.Text = " ";
            btn21.Text = " ";
            btn22.Text = " ";

            foreach (Button b in c)
            {
                b.Enabled = true;
            }
            p = false;
            lb_risultato.Text = "";
            return segni;
        }
        private void StampaRisultato(string ris)
        {
            if (ris.Contains("vincitore"))
            {
                lb_risultato.Text = ris;
            }
        }
        private void Pareggio(int click)
        {
            if(click == 9)
            {
                match--;
                if (match == 0)
                {
                    var c = Comandi.getAll(this, typeof(Button));
                    foreach (Button b in c)
                    {
                        b.Enabled = false;
                    }
                    btn_reset.Enabled = true;
                    btn_reset.Visible = true;
                }
                else
                {
                    segni = NextMatch();
                }
                lb_match.Text = "" + match;
            }
        }
        //Schema tris
        private void btn00_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn00.Text = "X";
                turno = 1;
                btn00.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn00.Text = "O";
                turno = 0;
                btn00.Enabled = false;
                lb_turno.Text = Turno(turno);
               
            }*/
            
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn01_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn01.Text = "X";
                turno = 1;
                btn01.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn01.Text = "O";
                turno = 0;
                btn01.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[1] = btn01.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn02_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn02.Text = "X";
                turno = 1;
                btn02.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn02.Text = "O";
                turno = 0;
                btn02.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[2] = btn02.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn10.Text = "X";
                turno = 1;
                btn10.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn10.Text = "O";
                turno = 0;
                btn10.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[3] = btn10.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn11.Text = "X";
                turno = 1;
                btn11.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn11.Text = "O";
                turno = 0;
                btn11.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[4] = btn11.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn12_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn12.Text = "X";
                turno = 1;
                btn12.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn12.Text = "O";
                turno = 0;
                btn12.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[5] = btn12.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn20_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn20.Text = "X";
                turno = 1;
                btn20.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn20.Text = "O";
                turno = 0;
                btn20.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[6] = btn20.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn21_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn21.Text = "X";
                turno = 1;
                btn21.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn21.Text = "O";
                turno = 0;
                btn21.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[7] = btn21.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        private void btn22_Click(object sender, EventArgs e)
        {
            p = true;
            if (turno == 0)
            {
                btn22.Text = "X";
                turno = 1;
                btn22.Enabled = false;
                lb_turno.Text = Turno(turno);
                Move mossa = new Move();
                Move move = new Move();
                move = Attacco(combo_vincenti);
                if (move.row == -1 && move.col == -1)
                {
                    mossa = findBestMove(caselle, combo_vincenti);
                    caselle[mossa.row, mossa.col].Text = "O";
                    caselle[mossa.row, mossa.col].Enabled = false;
                }
                else
                {
                    caselle[move.row, move.col].Text = "O";
                    caselle[move.row, move.col].Enabled = false;
                }
            }/*
            else
            {
                btn22.Text = "O";
                turno = 0;
                btn22.Enabled = false;
                lb_turno.Text = Turno(turno);
            }*/
            segni[8] = btn22.Text;
            ris = Comandi.Vincita(segni);
            StampaRisultato(ris);
            click++;
            Pareggio(click);
        }
        //Fine Schema Tris

        private void lb_risultato_TextChanged(object sender, EventArgs e)
        {
            if (p == true && lb_risultato.Text.Contains("vincitore"))
            {
                match--;
                Vinte(segni);
                VerificaPunteggio();
            }
            
            if (match == 0)
            {
                btn_reset.Visible = true;
            }
            else
            {
                segni = NextMatch();
            }
            lb_match.Text = "" + match;
        }
        
        private void btn_reset_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Visible = false;
        }


        //Funzione per assegnare un punteggio alla situzione del gioco (+10 se vince la X / -10 se vince la O / 0 se è un pareggio)
        private static int VerificaVincita(Button[,] bottoni)
        {
            for (int row = 0; row < 3; row++)
            {
                if (bottoni[row, 0].Text == bottoni[row, 1].Text && bottoni[row, 1].Text == bottoni[row, 2].Text)
                {
                    if (bottoni[row, 0].Text == "X")
                        return +10;
                    else if (bottoni[row, 0].Text == "O")
                        return -10;
                }
            }

            // Checking for Columns for X or O victory.
            for (int col = 0; col < 3; col++)
            {
                if (bottoni[0, col].Text == bottoni[1, col].Text && bottoni[1, col].Text == bottoni[2, col].Text)
                {
                    if (bottoni[0, col].Text == "X")
                        return +10;
                    else if (bottoni[0, col].Text == "O")
                        return -10;
                }
            }

            // Checking for Diagonals for X or O victory.
            if (bottoni[0, 0].Text == bottoni[1, 1].Text && bottoni[1, 1].Text == bottoni[2, 2].Text)
            {
                if (bottoni[0, 0].Text == "X")
                    return +10;
                else if (bottoni[0, 0].Text == "O")
                    return -10;
            }
            if (bottoni[0, 2].Text == bottoni[1, 1].Text && bottoni[1, 1].Text == bottoni[2, 0].Text)
            {
                if (bottoni[0, 2].Text == "X")
                    return +10;
                else if (bottoni[0, 2].Text == "O")
                    return -10;
            }
            Console.WriteLine("Esuguo Verifica Vincita");

            // Else if none of them have won then return 0
            return 0;
        }

        //Funzione per verificare se ci sono ancora mosse disponibili
        static Boolean isMovesLeft(Button[,] bottoni)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (bottoni[i, j].Text == "")
                        return true;
            return false;
        }

        //Funzione minimax
        static int minimax(Button[,] bottoni, int profondita, Boolean isMax)
        {
            int score = VerificaVincita(bottoni);

            // If Maximizer has won the game
            // return his/her evaluated score
            if (score == 10)
                return score;

            // If Minimizer has won the game
            // return his/her evaluated score
            if (score == -10)
                return score;

            // If there are no more moves and
            // no winner then it is a tie
            if (isMovesLeft(bottoni) == false)
                return 0;

            // Se è la mossa del massimizzatore
            if (isMax)
            {
                Console.WriteLine("Funzione minimax nel ramo del massimizzatore");
                int best = -1000;

                // Scorro tutte le caselle
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Verifico se la casella è vuota
                        if (bottoni[i, j].Text == " ")
                        {
                            // Fai la mossa
                            bottoni[i, j].Text = "X";

                            // Richiamo la funzione minimax in modo ricorsiovo
                            // e scelgo il massimo valore
                            best = Math.Max(best, minimax(bottoni, profondita + 1, !isMax));
                            // Scarta la mossa
                            bottoni[i, j].Text = " ";
                        }
                    }
                }
                return best;
            }

            // Se è la mossa del minimizzatore
            else
            {
                Console.WriteLine("funzione minimax nel ramo del minimizzatore");
                int best = 1000;

                //  Scorro tutte le caselle
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Verifico se la casella è vuota
                        if (bottoni[i, j].Text == " ")
                        {
                            // Make the move
                            bottoni[i, j].Text = "O";

                            // Richiamo la funzione minimax in modo ricorsiovo
                            // e scelgo il minimo valore
                            best = Math.Min(best, minimax(bottoni, profondita + 1, !isMax));

                            // Scarto la mossa
                            bottoni[i, j].Text = " ";
                        }
                    }
                }
                return best;
            }
        }


        //funzione per cercare la mossa migliore
        static Move findBestMove(Button[,] bottoni, List<int[]> vincenti)
        {
                Console.WriteLine("Inizio Funzione Findbest");
                int bestVal = -1000;
                Move bestMove = new Move();
                bestMove.row = -1;
                bestMove.col = -1;

                // Traverse all cells, evaluate minimax function
                // for all empty cells. And return the cell
                // with optimal value.
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        do
                        {
                            // Check if cell is empty
                            if (bottoni[i, j].Text == " ")
                            {

                                // Make the move
                                bottoni[i, j].Text = "X";

                                // compute evaluation function for this
                                // move.
                                int moveVal = minimax(bottoni, 0, false);
                                // Undo the move
                                bottoni[i, j].Text = " ";

                                // If the value of the current move is
                                // more than the best value, then update
                                // best/
                                if (moveVal > bestVal)
                                {
                                    bestMove.row = i;
                                    bestMove.col = j;
                                    bestVal = moveVal;
                                }
                            }
                            Console.WriteLine("r: " + i + " c " + j);
                        } while (bottoni[i, j].Text.Equals("X") && bottoni[i, j].Text.Equals("O"));
                        Console.WriteLine("Fuori");
                    }
                }
                Console.WriteLine("Fine Funzione Findbest");
                Console.Write("The value of the best Move is : {0}\n\n", bestVal);
                turno = 0;
                return bestMove;
            
        }

        private static Move Attacco(List<int[]> vincenti)
        {
            Move attacco = new Move();
            attacco.row = -1;
            attacco.col = -1;
            {
                for (int row = 0; row < 3; row++)
                {
                    if (caselle[row, 0].Text == "O" && caselle[row, 1].Text == "O" && caselle[row, 2].Text == " ")
                    {
                        attacco.row = row;
                        attacco.col = 2;
                        break;
                    }
                    else if (caselle[row, 2].Text == "O" && caselle[row, 1].Text == "O" && caselle[row, 0].Text == " ")
                    {
                        attacco.row = row;
                        attacco.col = 0;
                        break;
                    }
                    else if (caselle[row, 2].Text == "O" && caselle[row, 0].Text == "O" && caselle[row, 1].Text == " ")
                    {
                        attacco.row = row;
                        attacco.col = 1;
                        break;
                    }
                }

                // Checking for Columns for X or O victory.
                for (int col = 0; col < 3; col++)
                {
                    if (caselle[0, col].Text == "O" && caselle[1, col].Text == "O" && caselle[2, col].Text == " ")
                    {
                        attacco.row = 2;
                        attacco.col = col;
                        break;
                    }
                    else if (caselle[2, col].Text == "O" && caselle[1, col].Text == "O" && caselle[0, col].Text == " ")
                    {
                        attacco.row = 0;
                        attacco.col = col;
                        break;
                    }
                    else if (caselle[2, col].Text == "O" && caselle[0, col].Text == "O" && caselle[1, col].Text == " ")
                    {
                        attacco.row = 1;
                        attacco.col = col;
                        break;
                    }
                }

                // Checking for Diagonals for X or O victory.
                if (caselle[0, 0].Text == "O" && caselle[1, 1].Text == "O" && caselle[2, 2].Text == " ")
                {
                    attacco.row = 2;
                    attacco.col = 2;
                }
                else if (caselle[0, 0].Text == "O" && caselle[2, 2].Text == "O" && caselle[1, 1].Text == " ")
                {
                    attacco.row = 1;
                    attacco.col = 1;
                }
                else if (caselle[2, 2].Text == "O" && caselle[1, 1].Text == "O" && caselle[0, 0].Text == " ")
                {
                    attacco.row = 0;
                    attacco.col = 0;
                }

                if (caselle[0, 2].Text == "O" && caselle[1, 1].Text == "O" && caselle[2, 0].Text == " ")
                {
                    attacco.row = 2;
                    attacco.col = 0;
                }
                else if (caselle[0, 2].Text == "O" && caselle[2, 0].Text == "O" && caselle[1, 1].Text == " ")
                {
                    attacco.row = 1;
                    attacco.col = 1;
                }
                else if (caselle[2, 0].Text == "O" && caselle[1, 1].Text == "O" && caselle[0, 2].Text == " ")
                {
                    attacco.row = 0;
                    attacco.col = 2;
                }
                Console.WriteLine("Mossa Attacco" + attacco.row + "  " + attacco.col);

                // Else if none of them have won then return 0
                return attacco;
            }
        }
    } 
}
