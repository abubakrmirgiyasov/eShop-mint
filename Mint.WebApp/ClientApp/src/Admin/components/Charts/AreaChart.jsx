import React from "react";
import getChartColorsArray from "../../../helpers/colorsGeneratorHelper";
import ReactApexChart from "react-apexcharts";

const AreaChart = ({ dataColors }) => {
  const areaChartColors = getChartColorsArray(dataColors);
  const generateDayWiseTimeSeries = function (baseVal, count, yRange) {
    let i = 0;
    let series = [];

    while (i < count) {
      let x = baseVal;
      let y =
        Math.floor(Math.random() * (yRange.max - yRange.min + 1)) + yRange.min;

      series.push([x, y]);
      baseVal += 86400000;
      i++;
    }
    return series;
  };

  const series = [
    {
      name: "South",
      data: generateDayWiseTimeSeries(
        new Date("11 Feb 2017 GMT").getTime(),
        20,
        {
          min: 10,
          max: 60,
        }
      ),
    },
    {
      name: "North",
      data: generateDayWiseTimeSeries(
        new Date("11 Feb 2017 GMT").getTime(),
        20,
        {
          min: 10,
          max: 20,
        }
      ),
    },
    {
      name: "Central",
      data: generateDayWiseTimeSeries(
        new Date("11 Feb 2017 GMT").getTime(),
        20,
        {
          min: 10,
          max: 15,
        }
      ),
    },
  ];

  const options = {
    chart: {
      type: "area",
      height: 350,
      stacked: true,
      toolbar: {
        show: false,
      },
      events: {
        selection: function (chart, e) {
          console.log(new Date(e.xaxis.min));
        },
      },
    },
    colors: areaChartColors,
    dataLabels: {
      enabled: false,
    },
    stroke: {
      curve: "smooth",
    },
    fill: {
      type: "gradient",
      gradient: { opacityFrom: 0.6, opacityTo: 0.8 },
    },
    legend: { position: "top", horizontalAlign: "left" },
    xaxis: { type: "datetime" },
  };

  return (
    <ReactApexChart
      options={options}
      series={series}
      type={"area"}
      height={350}
      className="apex-charts"
    />
  );
};

export default AreaChart;
