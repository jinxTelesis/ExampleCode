package com.example.dre.individualprojectquest2v1.View;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.example.dre.individualprojectquest2v1.Constants.Constant;
import com.example.dre.individualprojectquest2v1.MyArrayAdapter;
import com.example.dre.individualprojectquest2v1.R;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class ScoreInflatorActivity extends AppCompatActivity {

    /** the ScoreInflatorActivity reads the top 3 scores
     *  which 3 are top is determined in another part of the program
     *  and is only read here
     */

    private TextView tVScore1;
    private TextView tVScore2;
    private TextView tVScore3;
    private TextView tVScore4;
    private TextView tVScore5;
    private Button btnReturn;

    private SharedPreferences myPrefs;


    private String topScoreSoFar = "";
    private String secondScore = "";
    private String thirdScore = "";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_score_inflator);

        btnReturn = (Button) findViewById(R.id.buttonReturn);
        btnReturn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(ScoreInflatorActivity.this, quizSelection.class);
                startActivity(intent);
                finish();
            }
        });

        tVScore1 = (TextView) findViewById(R.id.textViewScoreID1);
        tVScore2 = (TextView) findViewById(R.id.textViewScoreID2);
        tVScore3 = (TextView) findViewById(R.id.textViewScoreID3);


        // pulls data in from shared preferences file for the top 3 scores
        // tests if it is not null before setting it 
        myPrefs = getSharedPreferences(Constant.PREFS_SCORE, 0);
        SharedPreferences.Editor editor = myPrefs.edit();
        topScoreSoFar = myPrefs.getString("TopScore",null);
        secondScore = myPrefs.getString("SecondScore", null);
        thirdScore = myPrefs.getString("ThirdScore",null);

        if(topScoreSoFar != null)
        {
            tVScore1.setText(topScoreSoFar);
        }
        else
        {
            tVScore1.setText("0");
        }

        if(secondScore !=null)
        {
            tVScore2.setText(secondScore);
        }
        else
        {
            tVScore2.setText("0");
        }

        if(thirdScore !=null)
        {
            tVScore3.setText(thirdScore);
        }
        else
        {
            tVScore3.setText("0");
        }
    }
}
