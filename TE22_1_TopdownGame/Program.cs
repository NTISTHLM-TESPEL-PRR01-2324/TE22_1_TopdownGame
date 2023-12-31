﻿using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);


// int x = 0;
// Vector2 position = new Vector2(0, 0);
Vector2 movement = new Vector2(0, 0);

Color hotPink = new Color(255, 105, 180, 255);

Rectangle doorRect = new Rectangle(760, 20, 32, 32);

Rectangle characterRect = new Rectangle(300, 400, 64, 64);
Texture2D characterImage = Raylib.LoadTexture("gubbe.png");

float speed = 5;

string scene = "start";

int points = 0;

while (!Raylib.WindowShouldClose())
{
  if (scene == "game")
  {
    movement = Vector2.Zero;

    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
    {
      movement.Y = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
    {
      movement.Y = 1;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
    {
      movement.X = -1;
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
    {
      movement.X = 1;
    }

    // Om karaktärern rör sig, normalisera rörelsen och använd speed
    if (movement.Length() > 0)
    {
      movement = Vector2.Normalize(movement) * speed;
    }
    characterRect.x += movement.X;
    characterRect.y += movement.Y;

    if (characterRect.x > 800 - 64 || characterRect.x < 0)
    {
      characterRect.x -= movement.X;
    }
      // characterRect.y -= movement.Y;


    // if (characterRect.x > 800)
    // {
    //   characterRect.x = -64;
    // }

    // Kolla kollisioner

    if (Raylib.CheckCollisionRecs(characterRect, doorRect))
    {
      // scene = "finished";
      points++;
    }

  }
  else if (scene == "start")
  {
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
    {
      scene = "game";
    }
  }
  // x++;

  // --------------------------------------------------------------------------
  //  DRAWING
  // --------------------------------------------------------------------------

  Raylib.BeginDrawing();
  if (scene == "game")
  {
    Raylib.ClearBackground(Color.GOLD);

    Raylib.DrawRectangleRec(doorRect, hotPink);

    Raylib.DrawTexture(characterImage, (int)characterRect.x, (int)characterRect.y, Color.WHITE);

    Raylib.DrawText(points.ToString(), 10, 10, 32, Color.WHITE);
  }
  else if (scene == "start")
  {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawText("PRESS SPACE TO START", 10, 10, 32, Color.WHITE);
  }
  else if (scene == "finished")
  {
    Raylib.ClearBackground(Color.YELLOW);
  }

  // Raylib.DrawCircleV(position, 50, hotPink);
  // Raylib.DrawCircle(x, 300, 50, hotPink);

  // Raylib.DrawRectangle(10, 40, 300, 50, Color.BLACK);
  // Raylib.DrawRectangleRec(wall, Color.WHITE);

  Raylib.EndDrawing();
}