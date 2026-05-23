BlazorGraphs is a **lightweight SVG chart library for Blazor** with **no Javascript dependency**.
Build fast, interactive charts and gauges using pure Blazor rendering:

- Pure Blazor rendering (no JS interop)
- Lightweight SVG output
- Zero external dependencies
- Simple API, fast integration

## Links

- 🔗 Repository: https://github.com/EdoParis/BlazorCharts
- 🌐 Documentation: https://edoparis.github.io/BlazorCharts/
- 📦 NuGet: https://www.nuget.org/packages/BlazorGraphs

## Charts
- Histogram
- Line chart
- Bar chart
- Pie chart
- Donut chart
- Polar chart
- Radar chart

## Gauges
- Linear gauge
- Semicircle gauge 

## Namespaces
- BlazorGraphs.Enums
- BlazorGraphs.Gauges
- BlazorGraphs.Charts
- BlazorGraphs.Models
- BlazorGraphs.Legends
- BlazorGraphs.Structures	

## How to use
Each chart or gauge have a dedicated data model as parameter, the data model contains all the data needed to draw the chart.

Each data model has two methods:
- `Add`: to add new data to the model
- `Clear`: to remove all the existing data from the model

Use the data structures you find in `BlazorGraphs.Structures` to fill the data model.

#### Legends
The legend component is separated from the charts, and has a dedicated namespace `BlazorGraphs.Legends`, which contains:
- the component `LegendBar`
- the struct `LegendItem`

The `LegendBar` component accepts the same data models of charts as parameter, since this is separated from the chart, you can place everywhere you want and if horizontally or vertically oriented.

#### Histogram example
This renders a fully interactive SVG histogram.
```
<HistChart Model="@histogram"></HistChart>

@{
    histogram = new Histogram("asseX", "asseY", KnownColor.CadetBlue);

    for (int i = 0; i < 10; i++)
    {
        histogram.Add(new Bin()
        {
            Min = i, //bin left side
            Max = i + 1, //bin right side
            Value = 10 + i //bin height
        });
    }
}
```
#### Barchart example
This renders a fully interactive SVG bar chart.
```
<BarChart Model="@bargram"  
          Direction="@Positioning.Vertical">
</BarChart>

@{
    bargram = new Bargram("asseY", KnownColor.RoyalBlue);

    for (int i = 0; i < 10; i++)
    {
        bargram.Add(new Bar()
        {
            Label = $"Bar-{i}", //bar label
            Value = 10 + i //bar height
        });
    }
}
```

#### Linechart example
This renders a fully interactive SVG linechart, with the legend at the bottom of the chart.
```
<LineChart Model="@linegram"></LineChart>
<LegendBar Model="@linegram" 
           Direction="Positioning.Horizontal">
</LegendBar>

@{
    linegram = new Linegram("X1", "Y1");

    List<PointF> points1 = new();
    List<PointF> points2 = new();
    List<PointF> points3 = new();
    List<PointF> points4 = new();

    for (int i=0; i<10; i++)
    {
        points1.Add(new PointF(i, i));
        points2.Add(new PointF(i, i + 2));
        points3.Add(new PointF(i, i + 3));
        points4.Add(new PointF(i, i + 4));
    }

    linegram.Add(new Line("F1", KnownColor.LimeGreen, points1));
    linegram.Add(new Line("F2", KnownColor.OrangeRed, points2, DrawMode.Drawline));
    linegram.Add(new Line("F3", KnownColor.CadetBlue, points3, DrawMode.Drawpoints));
    linegram.Add(new Line("F4", KnownColor.DodgerBlue, points4, DrawMode.Drawpoints | DrawMode.Drawline));
}
```

#### Gauge example
This renders a fully interactive SVG linear gauge, the breakpoints are optional.
```
<LinearGauge Model="@gaugegram"></LinearGauge>

@{
    gaugegram = new Gaugegram(0, 500, "G1", KnownColor.Navy);
    gaugegram.Value = 175;
    gaugegram.AddBreakpoint(new Breakpoint()
    {
        Value = 150,
        Color = KnownColor.Green,
        Label = "LV-1"
    });
    gaugegram.AddBreakpoint(new Breakpoint()
    {
        Value = 250,
        Color = KnownColor.Gold,
        Label = "LV-2"
    });
    gaugegram.AddBreakpoint(new Breakpoint()
    {
        Value = 500,
        Color = KnownColor.Red,
        Label = "LV-3"
    });
}
```