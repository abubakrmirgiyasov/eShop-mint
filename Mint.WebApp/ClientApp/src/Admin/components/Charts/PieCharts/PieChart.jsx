import React from 'react';
import ReactApexChart from 'react-apexcharts';

const PieChart = () => {
    const chartDonutColors = ["--vz-primary", "--vz-success", "--vz-warning", "--vz-danger", "--vz-info"];
    const series = [44, 55, 13, 33];
    const options = {
        chart: { height: 280, type: "donut", },
        dataLabels: { enabled: false, },
        legend: { position: "bottom", },
        colors: chartDonutColors,
    };

    return (
        <ReactApexChart 
            className="apex-charts"
            series={series}
            options={options}
            type={"donut"}
            height={267.7}
        />
    );
}

export default PieChart;
