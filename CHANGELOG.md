# Changelog
Legend symbols:
* 🟩 **Feature**
* 🟦 **Improvement**
* 🟪 **Refactoring**
* 🟨 **Change**
* 🟥 **Bug**

## Version 3.0
* 🟩 Circular parameter to RadarChart
* 🟩 InnerAxis parameter to Speedometer
* 🟩 Scatter chart
* 🟩 Stepline chart
* 🟩 Bubbles chart
* 🟦 Centralized axis rendering
* 🟦 Centralized text rendering
* 🟪 Refactoring Line chart
* 🟪 Replaced Linegram and Line models with Cartesiangram
* 🟪 Reduced namespaces to only BlazorGraphs and BlazorGraphs.Components
* 🟨 Changed color properties to use Color type instead of KnownColor enum
* 🟨 Unified Polargram and Piegram models to Circulargram
* 🟨 Renamed BarChart as VerticalBarChart
* 🟨 Renamed PolarChart as PolarAreaChart
* 🟨 Renamed LinearGauge as HorizontalGauge
* 🟨 Removed obsolete component LegendBar
* 🟨 Removed enums

## Version 2.4
* 🟩 Vertical gauge
* 🟩 Speedometer
* 🟩 Add Reverse parameter to Linear and Vertical gauges
* 🟪 Split legend in two separated components, one to draw vertical and the other to draw horizontally
* 🟨 Mark Obsolete the old legendbar component

## Version 2.3
* 🟩 Add theme to charts, gauges and legend
* 🟦 Optimized barcharts and radarchart svg drawing
* 🟦 Improved labels positioning
* 🟥 Fix title of svg elements
* 🟥 Fix grid in radar and polar charts

## Version 2.2
* 🟩 Add secondary color to histogram for negative bars
* 🟩 Add secondary color to barchart for negative bars
* 🟪 Split barchart in two separated components, one to draw vertical and the other to draw horizontally
* 🟨 Mark Obsolete the direction parameter in barchart component
* 🟥 Fix pie and donut charts orientation

## Version 2.1
* 🟩 Linear gauge
* 🟩 Semicircle gauge
* 🟦 Use hex-string to define color of svg elements

## Version 2.0
* 🟪 Refactoring legend bar
* 🟨 Removed Legend data model
* 🟨 Moved color parameter from chart components to data models

## Version 1.4
* 🟩 Legend bar
* 🟩 Added Parameter to barchart to draw horizontally or vertically
* 🟦 Adapted horizontal axis positioning of histogram to show negative/positive bars

## Version 1.3
* 🟩 Donut chart
* 🟦 Added hover animations to charts
* 🟦 Added DrawMode flags for linechart

## Version 1.2
* 🟩 Radar chart
* 🟥 Fix label ticks

## Version 1.1
* 🟩 Polar chart
* 🟥 Fix charts visualization for empty data models

## Version 1.0
* 🟩 Histogram
* 🟩 Bar chart
* 🟩 Line chart
* 🟩 Pie chart