export const Roles = {
  Admin: { value: "77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4", label: "Админ" },
  Seller: { value: "8d8d8618-c897-48d4-bedc-83ba3db4b7e1", label: "Продавец" },
  Buyer: { value: "4d442669-abe7-4726-af0f-5734879a113c", label: "Покупатель" },
  Test: { value: "4d442669-abe7-4726-af0f-5734879a1133", label: "Test" },
  All: [
    { value: "77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4", label: "Админ" },
    { value: "8d8d8618-c897-48d4-bedc-83ba3db4b7e1", label: "Продавец" },
    { value: "4d442669-abe7-4726-af0f-5734879a113c", label: "Покупатель" },
    { value: "4d442669-abe7-4726-af0f-5734879a1133", label: "Test" },
  ],
  hasRole: checkHasRole,
};

function checkHasRole(need, has) {
  const [long, short] =
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

      if (short[center] < needle) 
        start = center + 1;
      else if (short[center] > needle) 
        finish = center - 1;
      else 
        return true;
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
