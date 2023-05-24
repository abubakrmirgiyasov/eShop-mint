const getChartColorsArray = (colors) => {
  colors = JSON.parse(colors);

  return colors.map(function (value) {
    let newValue = value.replace(" ", "");

    if (newValue.indexOf(",") === -1) {
        let color = getComputedStyle(document.documentElement).getPropertyValue(newValue);

        if (color.indexOf("#") !== -1) 
            color = color.replace(" ", "");
        
        return color ? color : newValue;
    } else {
        let val = value.split(',');

        if (val.length === 2) {
            let rgbaColor = getComputedStyle(document.documentElement).getPropertyValue(val[0]);
            rgbaColor = `rgba(${rgbaColor},${val[1]})`;
            return rgbaColor;
        } else {
            return newValue;
        }
    }
  });
};

export default getChartColorsArray;