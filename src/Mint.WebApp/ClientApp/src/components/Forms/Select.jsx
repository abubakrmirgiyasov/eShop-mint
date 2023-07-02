import React, { useEffect, useState } from "react";
import Select from "react-select";
import { FormFeedback, Label } from "reactstrap";

const MySelect = ({ label, isRequired, newData, ...props }) => {
  const [isSelected, setIsSelected] = useState(isRequired);

  useEffect(() => {
    setIsSelected(isRequired);
  }, [isRequired, isSelected]);

  const handleChange = (e) => {
    setIsSelected(true);
    newData(e);
  };

  return (
    <React.Fragment>
      <Label htmlFor={props.id}>{label}</Label>
      <Select id={props.id} onChange={handleChange} {...props} />
      <FormFeedback
        type={"invalid"}
        className={isSelected ? "d-none" : "d-block"}
      >
        {props.placeholder}
      </FormFeedback>
    </React.Fragment>
  );
};

export default MySelect;
