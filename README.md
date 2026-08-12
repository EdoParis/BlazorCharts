Existing Blazor chart libraries often wrap Javascript libraries, requiring JSInterop and external dependencies.
**BlazorGraphs** was built to provide a fully native Blazor experience using only **C# and SVG**.

Main features:
- Native Blazor
- SSR friendly
- WASM
- SVG
- No JS

The library clearly distinguishes between the **data representation model** and the **graphics rendering**. 
This way, you populate the model entirely in C#, and then pass it directly to the chart component.

Some components share the same data model, such as gauges, or the pie chart and the donut chart. 
This way, to change visualizations, you simply assign the model to the other compatible component with zero code rewrites.

## Links

- 🔗 Repository: https://github.com/EdoParis/BlazorCharts
- 🌐 Documentation: https://edoparis.github.io/BlazorCharts/
- 📦 NuGet: https://www.BlazorGraphs.it

## Charts
- Histogram
- Vertical Barchart
- Horizontal Barchart
- Line chart
- Step chart
- Scatter chart
- Bubble chart
- Pie chart
- Donut chart
- Radar chart
- PolarArea chart

## Gauges
- Horizontal gauge
- Vertical gauge
- Semicircle gauge 
- Speedometer

## Namespaces
- BlazorGraphs	
- BlazorGraphs.Components

The root namespace contains all datamodels and structures needed to populate the charts, 
while `BlazorGraphs.Components` contains all the charting, gauges and legends components.

## How to use
Each chart or gauge have a dedicated data model as parameter, the data model contains all the data needed to draw the chart.

Each data model has two methods:
- `Add` or `AddSerie` : to add new data or a new serie if the model supports it
- `Clear`: to remove all the existing data from the model

#### Legends
The legend is separated from the charts, there are two separated components:
- `LegendHorizontal`
- `LegendVertical`

The legend components accepts the same data models of charts as parameter, since this is separated from the chart, you can place everywhere you want.

#### Themes
Is possible to customize the chart, gauges and legends simply passing the `Theme`. 
It allows you to customize:
- background color
- axis color
- text color
- font family

If you pass a partially empty theme, the library doesn't break. It delegates the fallback to the browser engine using native properties:
- background color defaults to Transparent
- text and axis colors fallback to currentColor
- font family defaults to Inherit


#### Histogram example
This renders a fully interactive SVG histogram.
```
<HistChart Model="@model"></HistChart>

@{
    Histogram model = new Histogram("asseX", "asseY", KnownColor.CadetBlue);

    for (int i = 0; i < 10; i++)
    {
        model.Add(new Bin()
        {
            Min = i, //bin left side
            Max = i + 1, //bin right side
            Value = 10 + i //bin height
        });
    }
}
```
#### Barchart example
This renders a fully interactive SVG vertical barchart, with negative bars colored differently from positive ones.
```
<VerticalBarChart Model="@model"/>

@{
    Bargram model = new Bargram("asseY", KnownColor.RoyalBlue, KnownColor.OrangeRed);

    for (int i = 0; i < 10; i++)
    {
        model.Add(new Bar()
        {
            Label = $"Bar-{i}", //bar label
            Value = 5 - i //bar height
        });
    }
}
```

#### Cartesian charts example
This renders a fully interactive SVG linechart, scatterchart and stepchart, all using the same datamodel.
```
<LineChart Theme="@Theme.Dark" Model="@model"/>
<StepChart Theme="@Theme.Dark" Model="@model"/>
<ScatterChart Theme="@Theme.Light" Model="@model"/>

@{
    Cartesiangram model = new Cartesiangram("X1", "Y1");

    List<Datapoint> points1 = new();
    List<Datapoint> points2 = new();
    List<Datapoint> points3 = new();
    List<Datapoint> points4 = new();

    for (int i=0; i<10; i++)
    {
        points1.Add(new Datapoint(i, i));
        points2.Add(new Datapoint(i, i + 2));
        points3.Add(new Datapoint(i, i + 3));
        points4.Add(new Datapoint(i, i + 4));
    }

    model.AddSerie("F1", KnownColor.LimeGreen, points1);
    model.AddSerie("F2", KnownColor.OrangeRed, points2);
    model.AddSerie("F3", KnownColor.CadetBlue, points3);
    model.AddSerie("F4", KnownColor.DodgerBlue, points4);
}
```

#### Gauge example
This renders a fully interactive SVG horizontal gauge, the breakpoints are optional.
```
<HorizontalGauge Theme="@Theme.Arctic" Model="@model" Reverse="false"/>

@{
    Gaugegram model = new Gaugegram(0, 500, "G1", KnownColor.Navy);
    model.Value = 175;
    model.AddBreakpoint(new Breakpoint()
    {
        Value = 150,
        Color = KnownColor.Green,
        Label = "LV-1"
    });
    model.AddBreakpoint(new Breakpoint()
    {
        Value = 250,
        Color = KnownColor.Gold,
        Label = "LV-2"
    });
    model.AddBreakpoint(new Breakpoint()
    {
        Value = 500,
        Color = KnownColor.Red,
        Label = "LV-3"
    });
}
```