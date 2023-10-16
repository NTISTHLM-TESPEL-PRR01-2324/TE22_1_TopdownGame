using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);


// int x = 0;
// Vector2 position = new Vector2(0, 0);
Vector2 movement = new Vector2(0, 0);

Color hotPink = new Color(255, 105, 180, 255);

Rectangle characterRect = new Rectangle(300, 400, 64, 64);
Texture2D characterImage = Raylib.LoadTexture("gubbe.png");

float speed = 5;

string scene = "start";

while (!Raylib.WindowShouldClose())
{
  if (scene == "game")
  {

    // position += movement;
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

    if (movement.Length() > 0)
    {
      movement = Vector2.Normalize(movement) * speed;
    }
    characterRect.x += movement.X;
    characterRect.y += movement.Y;
  }
  else if (scene == "start")
  {
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
    {
      scene = "game";
    }
  }
  // x++;
  Raylib.BeginDrawing();
  if (scene == "game")
  {
    Raylib.ClearBackground(Color.GOLD);

    Raylib.DrawTexture(characterImage, (int)characterRect.x, (int)characterRect.y, Color.WHITE);
  }
  else if (scene == "start")
  {
    Raylib.ClearBackground(Color.BLUE);
    Raylib.DrawText("PRESS SPACE TO START", 10, 10, 32, Color.WHITE);
  }

  // Raylib.DrawCircleV(position, 50, hotPink);
  // Raylib.DrawCircle(x, 300, 50, hotPink);

  // Raylib.DrawRectangle(10, 40, 300, 50, Color.BLACK);
  // Raylib.DrawRectangleRec(wall, Color.WHITE);

  Raylib.EndDrawing();
}