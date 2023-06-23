import React, { useEffect, useState } from "react";
import {
  Accordion,
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Input,
  Label,
} from "reactstrap";
import Select from "react-select";
import Rating from "react-rating";
import { fetchWrapper } from "../../helpers/fetchWrapper";
import { Error } from "../Notification/Error";

const ProductSort = ({ data, dataForSearch, filteredData }) => {
  const [error, setError] = useState(null);
  const [manufactureArr, setManufactureArr] = useState([]);
  const [open, setOpen] = useState("1");

  useEffect(() => {
    fetchWrapper
      .get("api/manufacture/getonlymanufactures")
      .then((response) => {
        setManufactureArr(response);
      })
      .catch((error) => {
        setError(error);
      });
  }, []);

  const handleDiscountClick = (e) => {
    if (e.target.checked) {
      filteredData(dataForSearch.filter((item) => item.isDiscount));
    } else {
      filteredData(data);
    }
  };

  const handleRateClick = (e) => {
    filteredData(dataForSearch.filter((item) => item.rating <= e));
  };

  const toggle = (id) => {
    if (open === id) {
      setOpen("1");
    } else {
      setOpen(id);
    }
  };

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <Accordion
        className={"custom-accordionwithicon accordion-fill-success"}
        id={"accordionFill"}
        open={open}
        toggle={toggle}
      >
        <AccordionItem>
          <AccordionHeader targetId={"1"}>Цена</AccordionHeader>
          <AccordionBody id={"accordionFill"} accordionId={"1"}>
            <div className={"d-flex gap-1"}>
              <Input
                type={"number"}
                min={0}
                max={100000}
                placeholder={"От 0"}
              />
              <Input
                type={"number"}
                min={0}
                max={100000}
                placeholder={"До 100000"}
              />
            </div>
          </AccordionBody>
        </AccordionItem>
        <AccordionItem>
          <AccordionHeader targetId={"2"}>Производители</AccordionHeader>
          <AccordionBody id={"accordionFill"} accordionId={"2"}>
            <Select options={manufactureArr} defaultValue={[]} />
          </AccordionBody>
        </AccordionItem>
        <AccordionItem>
          <AccordionHeader targetId={"3"}>Рейтинг</AccordionHeader>
          <AccordionBody id={"accordionFill"} accordionId={"3"}>
            <Rating
              initialRating={0}
              emptySymbol={"mdi mdi-star-outline text-muted"}
              fullSymbol={"mdi mdi-star text-warning"}
              onClick={handleRateClick}
            />
          </AccordionBody>
        </AccordionItem>
        <AccordionItem>
          <h2 className={"accordion-header"} style={{ padding: ".5rem 1rem" }}>
            <Input
              id={"discount"}
              type={"checkbox"}
              className={"form-check-input me-2 mt-2"}
              style={{ width: "20px", height: "20px" }}
              onClick={handleDiscountClick}
            />
            <Label htmlFor={"discount"} className={"form-check-label fs-16"}>
              Только скидки
            </Label>
          </h2>
        </AccordionItem>
        <AccordionItem>
          <button
            type={"button"}
            color={"primary"}
            className={"btn btn-warning"}
            style={{ cursor: "pointer" }}
          >
            Сбросить
          </button>
        </AccordionItem>
      </Accordion>
    </React.Fragment>
  );
};

export { ProductSort };
