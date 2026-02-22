## Charts
- Histogram
- Line chart
- Bar chart
- Pie chart
- Donut chart
- Polar chart
- Radar chart

## Namespaces
- BlazorGraphs.Enums
- BlazorGraphs.Charts
- BlazorGraphs.Models
- BlazorGraphs.Structures	

## How to use

Each chart have a dedicated data model as parameter, the data model contains all the data needed to draw the chart.


Each data model has two methods:
- `Add`: to add new data to the model
- `Clear`: to remove all the existing data from the model


Use the data structures you find in `BlazorGraphs.Structures` to fill the data model.

### histogram example
```
<HistChart Model="@histogram" 
           Color="@KnownColor.CadetBlue">
</HistChart>
```
```
histogram = new Histogram("asseX", "asseY");

for (int i = 0; i < 10; i++)
{
    histogram.Add(new Bin()
    {
        Min = i, //bin left side
        Max = i + 1, //bin right side
        Value = 10 + i //bin height
    });
}
```

### barchart example
```
<BarChart Model="@bargram" 
          Color="@KnownColor.RoyalBlue" 
          Direction="@Positioning.Vertical">
</BarChart>
```
```
bargram = new Bargram("asseY");

for (int i = 0; i < 10; i++)
{
    bargram.Add(new Bar()
    {
        Label = $"Bar-{i}", //bar label
        Value = 10 + i //bar height
    });
}
```

### linechart example
```
<LineChart Model="@linegram"></LineChart>
```
```
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
```