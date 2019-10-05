using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils // przydatne funkcje matematyczne
{ // fun fact: wzory wykorzystałem kiedyś, znałem zasadę, a więc ich nie skopiowałem, tylko rozkminiłem sam :)
    public static float Norm(float amount, float min, float max)
    { // wynik to: ułamek z zakresu czyli np. Norm(150, 100, 200) da 0.5
        return (amount - min) / (max - min);
    }

    public static float Lerp(float dec, float min, float max)
    { // wynik to: liczba z zakresu odpowiadającemu ułamkowi np. Lerp(0.5, 100, 200) da 150
        return (max - min) * dec + min;
    }

    public static float Map(float amount, float inputMin, float inputMax, float outputMin, float outputMax)
    { // kombinuje dwie poprzednie funkcje mapując jeden zakres do drugiego np. Map(150, 100, 200, 1000, 2000) da 1500
        return Lerp(Norm(amount, inputMin, inputMax), outputMin, outputMax);
    }
    
    public static float distance(Vector2 a, Vector2 b)
    { // dystans między dwoma pozycjami
        return Mathf.Sqrt(((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y)));
    }
}
