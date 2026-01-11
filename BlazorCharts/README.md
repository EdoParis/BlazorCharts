## Charts
- Histogram
- Line chart
- Bar chart
- Pie chart
- Polar chart
- Radar chart

## Namespaces
- BlazorGraphs.Charts
- BlazorGraphs.Models
- BlazorGraphs.Structures	

## How to use

Each chart have a dedicated data model as parameter, the data model contains all the data needed to draw the chart.


Each data model has two methods:
- `Add`: to add new data to the model
- `Clear`: to remove all the existing data from the model


Use the data structures you find in `BlazorGraphs.Structures` to fill the data model.

#### histogram example
```
<HistChart Model="@histogram" Color="@KnownColor.CadetBlue"></HistChart>
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

#### barchart example
```
<BarChart Model="@bargram" Color="KnownColor.RoyalBlue"></BarChart>
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