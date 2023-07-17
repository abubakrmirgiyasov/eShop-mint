export function dateConverter(date: string) {
  const newDate = new Date(date);
  const month = newDate.getMonth() + 1; // months starts from 0-11
  const day = newDate.getDate();
  const year = newDate.getFullYear();
  return `${day}-${month}-${year}`;
}

export function getDay(date) {
  const newDate = new Date(date);
  return newDate.getDate();
}

export function getMonth(date) {
  const newDate = new Date(date);
  return newDate.getMonth() + 1; // months starts from 0-11
}

export function getYear(date) {
  const newDate = new Date(date);
  return newDate.getFullYear();
}
