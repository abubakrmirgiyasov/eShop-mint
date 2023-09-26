import styled from "styled-components";

export const SectionDivider = styled.div`
  & {
    position: relative;
    border-bottom: 1px solid var(--vz-dark);
    margin: 30px auto;
    max-width: 800px;
  }

  &:after {
    position: absolute;
    content: "";
    width: 20px;
    height: 20px;
    border: 1px solid var(--vz-success);
    left: 50%;
    margin-left: -10px;
    top: 50%;
    background: var(--vz-success);
    margin-top: -10px;
    -ms-transform: rotate(45deg);
    transform: rotate(45deg);
  }

  &:before {
    position: absolute;
    content: "";
    width: 30px;
    height: 30px;
    border: 1px solid var(--vz-light);
    left: 50%;
    margin-left: -15px;
    top: 50%;
    background: var(--vz-light);
    margin-top: -15px;
    -ms-transform: rotate(45deg);
    transform: rotate(45deg);
  }
`;
