import React from "react";
import classNames from "classnames";

const RadioButton = ({
  name,
  value,
  onChange,
  onBlur,
  id,
  label,
  className,
  ...props
}) => {
  return (
    <div>
      <input
        name={name}
        id={id}
        type="radio"
        defaultValue={id}
        checked={id === value}
        onChange={onChange}
        onBlur={onBlur}
        className="form-check-input"
        {...props}
      />
      <label htmlFor={id}>{label}</label>
    </div>
  );
};

export default RadioButton;
