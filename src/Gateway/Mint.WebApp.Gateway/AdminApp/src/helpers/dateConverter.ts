interface IDate {
  date: Date | string;
}

export const getFullDateWithTime = ({ date }: IDate): string => {
  const convertedDate = new Date(date.toString());
  const year = convertedDate.getFullYear();
  const month = convertedDate.getMonth() - 1;
  const day = convertedDate.getDay() + 1;
  const hours = convertedDate.getHours();
  const minutes = convertedDate.getMinutes();
  return `${day}-${month}-${year} ${hours}:${minutes}`;
};
