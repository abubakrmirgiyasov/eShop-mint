import React, { FC, useState, FocusEvent, ChangeEvent } from "react";
import { FormFeedback, Input, Label } from "reactstrap";

type Input = {
  id: string;
  type: string;
  name: string;
  required: boolean;
  hasLabel: boolean;
  label?: string;
  className?: string;
  placeholder?: string;
  value?: string;
  checked?: boolean;
  disabled?: boolean;
  isError?: boolean;
  error?: string;
  style?: React.CSSProperties;
  min?: number;
  max?: number;
  onChange?: (string) => void;
  onBlur?: (string) => void;
};

const MyInput: FC<Input> = (props) => {
  const {
    id,
    checked,
    type,
    name,
    className,
    value,
    placeholder,
    label,
    style,
    disabled,
    required,
    error,
    isError,
    hasLabel,
    min,
    max,
    onChange,
    onBlur,
  } = props;

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    if (onChange) {
      onChange(e.currentTarget.value);
    }
  };

  const handleBlur = (e: FocusEvent<HTMLInputElement>) => {
    if (onBlur) {
      onBlur(e.currentTarget.value);
    }
  };

  return (
    <React.Fragment>
      {hasLabel && <Label htmlFor={id}>{label}</Label>}
      <Input
        type={type}
        name={name}
        className={className}
        id={id}
        placeholder={placeholder}
        defaultValue={value}
        defaultChecked={checked}
        required={required}
        style={style}
        disabled={disabled}
        onChange={handleChange}
        onBlur={handleBlur}
        min={min}
        max={max}
      />
      {isError && (
        <FormFeedback
          type={"invalid"}
          className={isError ? "d-block" : "d-none"}
        >
          {error}
        </FormFeedback>
      )}
    </React.Fragment>
  );
};

export default MyInput;
