I think .NET Standard 2.0 is very very new . So Visual Studio 2017 or Visual Studio for Mac support not well . You need to do this if you want to change your development platrfrom.

#macOS  Build 

Coz github version was built at Windows . so you need to edit MVPPrismApp.Core.csproj repalce like this

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Prism.Autofac.Forms" Version="7.0.0.167-ci" />
    <PackageReference Include="Xamarin.FFImageLoading.Forms" Version="2.2.20" />
    <PackageReference Include="Microsoft.Composition" Version="1.0.31" />
    <PackageReference Include="Octane.Xam.VideoPlayer" Version="1.2.3" />
    <PackageReference Include="Xamarin.Forms" Version="2.4.0.18342" />
  </ItemGroup>
  <ItemGroup>
    <Folder Include="ViewModels\" />
    <Folder Include="Views\" />
    <Folder Include="Utils\" />
  </ItemGroup>

<ItemGroup>
    <EmbeddedResource Include="App.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\MainTabbedPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\MainPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\SchedulePage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\MapPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\VideoPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\GalleryPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\VideoPlayerPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\NetworkPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\VideoPlayerMacPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\NetworkPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
  </ItemGroup>
  <ItemGroup>
    <Compile Update="Views\MainTabbedPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\MapPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\SchedulePage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="App.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\VideoPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\GalleryPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\VideoPlayerPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\NetworkPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
    <Compile Update="Views\VideoPlayerMacPage.xaml.cs">
      <DependentUpon>*.xaml</DependentUpon>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\MVPPrismApp.Lib\MVPPrismApp.Lib.csproj" />
  </ItemGroup>
  <ItemGroup>
    <Reference Include="Newtonsoft.Json">
      <HintPath>..\lib\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include="DLToolkit.Forms.Controls.FlowListView">
      <HintPath>..\lib\DLToolkit.Forms.Controls.FlowListView.dll</HintPath>
    </Reference>
  </ItemGroup>
</Project>




#Windows Build

if you build only from Github , all is okay . But you change the build on macOS , movie it to Windows . you need to remove all for these in MVPPrismApp.Core.csproj

<ItemGroup>
    <EmbeddedResource Include="App.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\MainTabbedPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\MainPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\SchedulePage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\MapPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\VideoPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\GalleryPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\VideoPlayerPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\NetworkPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\VideoPlayerMacPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
    <EmbeddedResource Include="Views\NetworkPage.xaml">
      <Generator>MSBuild:UpdateDesignTimeXaml</Generator>
    </EmbeddedResource>
  </ItemGroup>







