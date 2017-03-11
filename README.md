#Ligen
Ligen is an architectural foundation for CLI utilities in the C# programming language. It uses a "{Module} {Command} {flags}" formation, which enables its users to set up any kind of modules and commands.

1) Inside the `Modules` folder, create a new module - be sure it's `Public` and `Static`.<br>
2) Next, create another `public static` function inside that module.<br>
3) Run the program, type the module name, the function name, and see what happens.<br>

Example:

Module file inside `Modules/`: `Say.cs`
Function inside `Say.cs`:

``` C#
public static void hi(){
  Console.WriteLine("Hello, World!");
}
```

If I now execute the application and type `Say hi`:<hr>
![Minion](http://image.prntscr.com/image/7cfe00b78d58419fb259c3c08d43896c.png)


## Flags


### Single Flag
Suppose we had another function that requires a parameter with the command, such as:

``` javascript
public static void age(string year)
{
    Console.WriteLine(DateTime.Now.Year - Convert.ToInt16(year) + " years old.");
}
```

All flags are passed in as strings by default, which will undoubtedly be changed soon to automatic parsing and conversion
of data-types.

But for now, this is an issue that needs to be dealt with individually within each action where the data type is not a string.

If I now run that command:<br>
`Say age 1990`:<hr>
![Minion](http://image.prntscr.com/image/46e811a27588416b810870b273a4a21a.png)


###Multiple Flags
The principle remains the same.

If you have a function with multiple arguments/params/flags etc. like this one:

``` C#
public static void introduce(string name, string age, string gender)
{
    Console.WriteLine(String.Format("Hey! I'm {0}, I'm currently {1} years old, and I'm {2}.", name, age, gender));
}
```
Running `Say introduce James 42 Male` outputs:<hr>
![Minion](http://image.prntscr.com/image/3ca9be6f164940df8864eaf7f1839658.png)

## Core

This architecture has a `Core` module which doesn't need to be specified when executing its commands. For example, `ls`.

The `ls` command, simply lists files and directories of the current directory; it's not necessary to specify `Core ls`, though that would also work:<hr:

![Minion](http://image.prntscr.com/image/752cb382e3cb41a1b9f3e4b72be47652.png)

As you can see in the result, both work.

You may add functions to the `Core` module if they are general, or if you simply do not wish to specify a module.


## Errors

Ligen has some built-in errors that you can change however you want to.

1) Calling a module that does not exist:<br>
`Ligen $ Roast `=> `Ligen $ No 'Roast' Module found.`

2) Calling a function in a module that doesn't exist:<br>
`Ligen $ Roast chicken`=> `Ligen $ No 'Roast' Module found.`

3) Calling a function that doesn't exist in a module that does exist.<br>
`Ligen $ Say random`=> `Ligen $ 'Say random' - no such command.`

3) Calling a function that doesn't exist in a module that does exist.<br>
`Ligen $ Say random`=> `Ligen $ 'Say random' - no such command.`

4) Calling a function without its required parameters.<br>
`Ligen $ Say introduce no`=> `Ligen $ 'Say introduce' expects 3 arguments.`<br>

Enjoy!










