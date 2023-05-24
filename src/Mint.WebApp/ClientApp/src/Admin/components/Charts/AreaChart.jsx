import React from "react";
import getChartColorsArray from "../../../helpers/colorsGeneratorHelper";
import ReactApexChart from "react-apexcharts";

const AreaChart = ({ dataColors, orders }) => {
  const areaChartColors = getChartColorsArray(dataColors);
  
  const getOrderRange = (time) => {
    return orders?.filter((order) => order.dateCreate >= time);
  };

  const today = new Date();

  const week = new Date();
  week.setDate(today.getDate() - 7);

  const month = new Date();
  month.setMonth(today.getDate() - 30);

  console.log(getOrderRange(today.toISOString().split("T")[0]));
  console.log(getOrderRange(week.toISOString().split("T")[0]));
  console.log(getOrderRange(month.toISOString().split("T")[0]));

  const series = [
    {
      name: "За сегодня",
      data: getOrderRange(today.toISOString().split("T")[0]),
    },
    {
      name: "За последние 7 дней",
      data: getOrderRange(week.toISOString().split("T")[0]),
    },
    {
      name: "За последние 30 дней",
      data: getOrderRange(month.toISOString().split("T")[0]),
    },
  ];

  const options = {
    chart: {
      type: "area",
      height: 350,
    },
    dataLabels: {
      enabled: false,
    },
    colors: areaChartColors,
    stroke: {
      curve: "smooth",
    },
    xaxis: {
      type: "datetime",
      categories: [
        today.toISOString().split("T")[0],
        week.toISOString().split("T")[0],
        month.toISOString().split("T")[0],
      ],
    },
    tooltip: {
      x: {
        format: "dd.MM.yy HH:mm",
      },
    },
    legend: { position: "top", horizontalAlign: "left" },
  };

  return (
    <ReactApexChart
      options={options}
      series={series}
      type={"area"}
      height={350}
      className={"apex-charts"}
    />
  );
};

export default AreaChart;
