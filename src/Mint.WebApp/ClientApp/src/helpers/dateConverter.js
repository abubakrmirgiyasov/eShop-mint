function dateConverter(date) {
  const newDate = new Date(date);
  const month = newDate.getMonth() + 1; //months from 1-12
  const day = newDate.getDate();
  const year = newDate.getFullYear();
  return day + "-" + month + "-" + year;
}

function getDay(date) {
  const newDate = new Date(date);
  return newDate.getDate();
}

function getMonth(date) {
  const newDate = new Date(date);
  return newDate.getMonth() + 1; //months from 1-12
}

function getYear(date) {
  const newDate = new Date(date);
  return newDate.getFullYear();
}

export { dateConverter, getDay, getYear, getMonth };
