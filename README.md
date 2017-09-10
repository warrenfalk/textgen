# TextGen

Super simple low legel text generation from C# using interpolated strings.

## For example:

Here is an example of generating some C# from C#, but you can generate any language.

```csharp
using static TextGen.Functions;

var name = "MyTest"

var output = Fragment(
	// use C# interpolated strings like this:
	$"namespace {name}Namespace",
    $"{",
    // indent code with blocks
    Block(
    	$"class {name}"
        $"{",
        ...
        $"}"
    ),
    $"}"
)
```

Yielding output like this

```csharp
namespace MyTestNamespace
{
	class MyTest
    {
    	...
    }
}
```

Extension is also super simple.  Create a function like this:

```chsarp
public static Block CurlyBlock(params Text[] items)
	=> Fragment(
    	$"{",
        Block(items),
        $"}"
    );
```

And the above example can be simplified to:

```csharp
using static TextGen.Functions;

var name = "MyTest"

var output = Fragment(
	// use C# interpolated strings like this:
	$"namespace {name}Namespace",
    // indent code with blocks
    CurlyBlock(
    	$"class {name}"
        CurlyBlock(
        	...
        )
    )
)
```

The possibilities are endless, and you can imagine creating many libraries derived from this library with functions designed specifically for target languages.