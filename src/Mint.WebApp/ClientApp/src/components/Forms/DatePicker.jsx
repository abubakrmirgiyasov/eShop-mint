import React, { useState } from "react";
import Flatpickr from "react-flatpickr";
import { FormFeedback } from "reactstrap";

const DatePicker = ({ isEdit, newDate, date, isValid, options }) => {
  const [isDateValid, setIsDateValid] = useState(!!date);

  const handleDateBlur = (e) => {
    if (e.target.value) {
      newDate(e.target.value);
      setIsDateValid(true);
      isValid(true);
    } else {
      newDate("");
      setIsDateValid(false);
      isValid(false);
    }
  };

  const handleDateChange = (e) => {
    if (e.length) {
      newDate(e);
      setIsDateValid(true);
      isValid(true);
    } else {
      newDate("");
      setIsDateValid(false);
      isValid(false);
    }
  };

  return (
    <React.Fragment>
      <Flatpickr
        type={"date"}
        name={"dateBirth"}
        id={"dateBirth"}
        className={`form-control ${isDateValid ? "" : "is-invalid"}`}
        disabled={isEdit}
        onChange={handleDateChange}
        onBlur={handleDateBlur}
        value={date}
        options={options}
      />
      <FormFeedback
        type={"invalid"}
        className={isDateValid ? "d-none" : "d-block"}
      >
        {"Заполните обязательное поле"}
      </FormFeedback>
    </React.Fragment>
  );
};

export default DatePicker;
