export function dateConverter(date: string): string {
  const newDate = new Date(date);
  const month = newDate.getMonth() + 1; // months starts from 0-11
  const day = newDate.getDate();
  const year = newDate.getFullYear();
  const i = day > 9 ? day : `0${newDate.getDate()}`;
  return `${i}-${month}-${year}`;
}

export function getDay(date: string): string {
  const newDate = new Date(date);
  return `${newDate.getDate()}`;
}

export function getMonth(date: string): string {
  const newDate = new Date(date);
  return `${newDate.getMonth() + 1}`; // months starts from 0-11
}

export function getYear(date: string): string {
  const newDate = new Date(date);
  return `${newDate.getFullYear()}`;
}
