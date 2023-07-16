interface IValue {
  value: string;
  label: string;
}

export const Roles = {
  Admin: { value: "ADMIN", label: "Админ" },
  Seller: { value: "SELLER", label: "Продовец" },
  Buyer: { value: "BUYER", label: "Покупатель" },
  All: [
    { value: "ADMIN", label: "Админ" },
    { value: "SELLER", label: "Продовец" },
    { value: "BUYER", label: "Покупатель" },
  ],
  hasRole: checkForRoleExist,
};

function checkForRoleExist(need: IValue[], has: IValue[]) {
  const [long, short]: [long: IValue[], short: IValue[]] =
    need.length > has.length
      ? [need.map((v) => v.value), has.map((v) => v.value)]
      : [has.map((v) => v.value), need.map((v) => v.value)];
  short.sort();

  const shortLength = short.length;

  const binSearch = (needle) => {
    let start = 0;
    let finish = shortLength - 1;

    while (start <= finish) {
      const center = Math.floor((start + finish) / 2);

      if (short[center] < needle) start = center + 1;
      else if (short[center] > needle) finish = center - 1;
      else return true;
    }
    return false;
  };

  const res = [];

  for (let i = 0, length = long.length; i < length; i++) {
    if (binSearch(long[i])) {
      res.push(long[i]);
    }
  }

  return res.length > 0;
}
