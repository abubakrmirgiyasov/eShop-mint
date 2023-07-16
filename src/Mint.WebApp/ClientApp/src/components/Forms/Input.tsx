import React, { FC } from "react";
import { FormFeedback, Input, Label } from "reactstrap";

interface IMyInput {
  type: string;
  name: string;
  id: string;
  className?: string;
  value?: string;
  error?: string;
  isError?: boolean;
  placeholder?: string;
  label?: string;
  required?: boolean;
  onChange?: () => void;
  onBlur?: () => void;
}

const MyInput: FC<IMyInput> = ({
  type,
  name,
  id,
  className,
  value,
  placeholder,
  label,
  ...props
}) => {
  console.log(props.isError, props.error);
  return (
    <React.Fragment>
      <Label htmlFor={id}>{label}</Label>
      <Input
        type={type}
        name={name}
        className={className}
        id={id}
        defaultValue={value}
        placeholder={placeholder}
        onChange={props.onChange}
        onBlur={props.onBlur}
      />
      {props.isError && (
        <FormFeedback type={"invalid"}>{props.error}</FormFeedback>
      )}
    </React.Fragment>
  );
};

export default MyInput;
