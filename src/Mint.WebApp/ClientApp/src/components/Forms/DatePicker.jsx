import React, { useState } from "react";
import Flatpickr from "react-flatpickr";
import { FormFeedback } from "reactstrap";

const DatePicker = ({ isEdit, newDate, date, isValid, options }) => {
  const [isDateBirthValid, setIsDateBirthValid] = useState(!!date);

  const handleDateBirthBlur = (e) => {
    if (e.target.value) {
      newDate(e.target.value);
      setIsDateBirthValid(true);
      isValid(true);
    } else {
      newDate("");
      setIsDateBirthValid(false);
      isValid(false);
    }
  };

  const handleDateBirthChange = (e) => {
    if (e.length) {
      newDate(e);
      setIsDateBirthValid(true);
      isValid(true);
    } else {
      newDate("");
      setIsDateBirthValid(false);
      isValid(false);
    }
  };

  return (
    <React.Fragment>
      <Flatpickr
        type={"date"}
        name={"dateBirth"}
        id={"dateBirth"}
        className={`form-control ${isDateBirthValid ? "" : "is-invalid"}`}
        disabled={isEdit}
        onChange={handleDateBirthChange}
        onBlur={handleDateBirthBlur}
        value={date}
        options={options}
      />
      <FormFeedback
        type={"invalid"}
        className={isDateBirthValid ? "d-none" : "d-block"}
      >
        {"Заполните обязательное поле"}
      </FormFeedback>
    </React.Fragment>
  );
};

export default DatePicker;
