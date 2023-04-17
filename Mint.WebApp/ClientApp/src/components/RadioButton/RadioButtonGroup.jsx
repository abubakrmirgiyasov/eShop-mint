import React from "react";
import classNames from "classnames";

const RadioButtonGroup = ({
  value,
  error,
  touched,
  className,
  children,
}) => {
  const InputFeedback = ({ error }) =>
    error ? <div className={classNames("input-feedback")}>{error}</div> : null;

  const classes = classNames(
    "input-field",
    {
      "is-success": value || (!error && touched), // handle prefilled or user-filled
      "is-error": !!error && touched,
    },
    className
  );

  return (
    <div className={classes}>
      <fieldset>
        {children}
        {touched && <InputFeedback error={error} />}
      </fieldset>
    </div>
  );
};

export default RadioButtonGroup;
