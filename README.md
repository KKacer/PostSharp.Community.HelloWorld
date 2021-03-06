## <img src="https://cdn4.iconfinder.com/data/icons/Hypic_Icon_Pack_by_shlyapnikova/64/plugin_64.png" width="32"> &nbsp; PostSharp.Community.HelloWorld 
An example add-in for [PostSharp](https://postsharp.net).

You can use the code in this repository as a base on which to build your own add-in for PostSharp.

*This is an add-in for [PostSharp](https://postsharp.net). It modifies your assembly during compilation by using IL weaving.*

## Creating an add-in
To create your PostSharp add-in using this template as a base, do the following:
1. Change "PostSharp.Community.HelloWorld" in all file names to the name of your add-in.
2. Change the text "PostSharp.Community.HelloWorld" in all files to the name/namespace of your add-in.
3. Replace the `HelloWorldAttribute` in the project `Client` with any attributes or classes that you want the user of your add-in to be able to access at IntelliSense time, build time and possibly runtime.
4. Update the class `HelloWorldTask` in the project `Weaver` with the code of your add-in.
5. Delete `LICENSE.md` or change it to a license of your choice.

Then, if you want to distribute the add-in as a NuGet package:
1. Update any other files, such as the `nuspec` file.
2. Use `nuget pack PostSharp.Community.HelloWorld.nuspec` to create a NuGet package from your add-in.
3. To use the add-in, the user just needs to add and install that NuGet package.

Or, if you want to distribute the add-in as a project or an assembly:
1. The user of the add-in must reference the NuGet package PostSharp.
2. The user of the add-in must reference the client assembly (`PostSharp.Community.HelloWorld.dll`) or the client assembly project (`Client`).
3. The directory that contains the weaver assembly (`PostSharp.Community.HelloWorld.Weaver.dll`) must be placed on the PostSharp search path with the MSBuild property `PostSharpSearchPath`. See the project `Tests` for an example on how to do this.

#### Building
Restore and build the solution to build both the add-in and the tests.

You need at least a Community license of PostSharp to build the Tests project. You can get this license for free 
at https://www.postsharp.net/get/free.

#### Testing
The add-in is included in the project file of `Tests`. This means:
 * The attributes you
define in the project `Client` can be used in the test project.
 * The weaver you define in the project `Weaver` processes that test project when the test project is built.

Tests you define in the test project therefore already see the enhanced code.

See the project file `Tests.csproj` for details on how add-in discovery works.

#### Build-time debugging
You can attach a debugger to the compiler as an assembly is being built to debug your add-in.

To do this, add the following lines to the `.csproj` file of the project where you're using the weaver. In this add-in, that would be `Tests.csproj`:

```xml
<PropertyGroup>
    <PostSharpAttachDebugger>True</PostSharpAttachDebugger>
    <PostSharpHost>Native</PostSharpHost>
</PropertyGroup>
```
Or build the project with the command line arguments `/P:PostSharpAttachDebugger=True /P:PostSharpHost=Native`.

Also, change the `<TargetFrameworks>` line to only target one framework.

If you choose .NET Framework, then PostSharp will trigger the just-in-time debugger window prompting you to attach a debugger.

If you choose .NET Core or .NET Standard, then PostSharp will wait indefinitely until you attach a debugger using "Attach to Running Process" functionality of a debugger.

We tested debugging with both Visual Studio and JetBrains Rider.

## Documentation of the HelloWorld add-in
This add-in adds the line `Console.WriteLine("Hello, world!");` at the beginning of each target method in your code.
 
#### Example
Your code:
```csharp
[HelloWorld]
static int ReturnTheAnswer() 
{
    return 42;
}
```
What gets compiled:
```csharp
static int ReturnTheAnswer() 
{
    Console.WriteLine("Hello, world!");
    return 42;
}
```

#### Installation (as a user of this plugin)
1. Install the NuGet package: `PM> Install-Package PostSharp.Community.HelloWorld`
2. Get a free PostSharp Community license at https://www.postsharp.net/get/free
3. When you compile for the first time, you'll be asked to enter the license key.

#### How to use
Add `[HelloWorld]` to the methods or classes where you want it to apply, or apply it to the entire assembly with [multicasting](https://doc.postsharp.net/attribute-multicasting).

#### Copyright notices
This example of a PostSharp add-in is released to the public domain.

Other PostSharp add-ins are generally released under the MIT license.

* The code in this repository was created by PostSharp Technologies.
* Icon by Shlyapnikova, https://www.iconfinder.com/icons/51412/24_plugin_icon, CC BY 3.0