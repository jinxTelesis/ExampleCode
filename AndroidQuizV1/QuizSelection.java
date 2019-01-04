package com.example.dre.individualprojectquest2v1.View;

import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.dre.individualprojectquest2v1.R;
import com.example.dre.individualprojectquest2v1.View.Questions1To5.Question1Activity;

public class QuizSelection extends AppCompatActivity {


    /** the quizSelection activity is a directory that leads to
     *  4 other activities and does nothing else
     */
    TextView tVQuizRules, tVQuizPlayGame, tVQuizTopScores, tVQuizQuestionMarks;
    Button btn;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz_selection);

        tVQuizRules = (TextView) findViewById(R.id.textViewQuizRules);
        tVQuizPlayGame = (TextView) findViewById(R.id.textViewQuizPlayGame);
        tVQuizTopScores = (TextView) findViewById(R.id.textViewQuizTopScore);
        tVQuizQuestionMarks = (TextView) findViewById(R.id.textViewQuizQuestionMarks);




        tVQuizRules.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent qTRIntent = new Intent(quizSelection.this, InstructionsActivity.class);
                startActivity(qTRIntent);
                finish();
            }
        });

        tVQuizPlayGame.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent qTPGIntent = new Intent(quizSelection.this, Question1Activity.class);
                startActivity(qTPGIntent);
                finish();
            }
        });

        tVQuizTopScores.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent qTSIntent = new Intent(quizSelection.this, ScoreInflatorActivity.class);
                startActivity(qTSIntent);
                finish();
            }
        });

        tVQuizQuestionMarks.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                Intent i = new Intent(Intent.ACTION_VIEW);
                i.setData(Uri.parse(url));
                startActivity(i);
            }
        });



    }
}
