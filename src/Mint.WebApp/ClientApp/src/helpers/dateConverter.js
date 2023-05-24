const dateConverter = ({ date }) => {
  const newDate = new Date(date);
  const month = newDate.getUTCMonth() + 1; //months from 1-12
  const day = newDate.getUTCDate();
  const year = newDate.getUTCFullYear();
  return day + " / " + month + " / " + year;
};

export { dateConverter };
