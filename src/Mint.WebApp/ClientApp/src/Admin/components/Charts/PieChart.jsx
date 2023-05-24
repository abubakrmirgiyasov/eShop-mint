import React from 'react';
import ReactApexChart from 'react-apexcharts';
import getChartColorsArray from '../../../helpers/colorsGeneratorHelper';

const PieChart = ({ dataColors }) => {
    const chartDonutColors = getChartColorsArray(dataColors);
    const series = [44, 55, 13, 33];
    const options = {
        chart: { height: 280, type: "pie", },
        dataLabels: { enabled: false, },
        legend: { position: "bottom", },
        colors: chartDonutColors,
    };

    return (
        <ReactApexChart 
            className="apex-charts"
            series={series}
            options={options}
            type={"pie"}
            height={267.7}
        />
    );
}

export default PieChart;
