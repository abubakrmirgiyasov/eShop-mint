import React, { useEffect, useState } from "react";
import {
  Accordion,
  AccordionBody,
  AccordionItem,
  Collapse,
  Input,
  Label,
} from "reactstrap";
import classnames from "classnames";
import Select from "react-select";
import Rating from "react-rating";
import { fetchWrapper } from "../../helpers/fetchWrapper";

const ProductSort = ({ data, dataForSearch, filteredData }) => {
  const [price, setPrice] = useState(true);
  const [manufactures, setManufactures] = useState(false);
  const [rating, setRating] = useState(false);
  const [error, setError] = useState(null);
  const [manufactureArr, setManufactureArr] = useState([]);

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

  const handlePriceClick = () => {
    setPrice(!price);
    setRating(false);
    setManufactures(false);
  };

  const handleManufacturesClick = () => {
    setPrice(false);
    setRating(false);
    setManufactures(!manufactures);
  };

  const handleRatingClick = () => {
    setPrice(false);
    setRating(!rating);
    setManufactures(false);
  };

  const handleDiscountClick = (e) => {
    if (e.target.checked) {
      filteredData(dataForSearch.filter((item) => item.isDiscount));
    } else {
      filteredData(data);
    }
  };

  return (
    <Accordion
      className={"custom-accordionwithicon accordion-fill-success"}
      id={"accordionFill"}
    >
      <AccordionItem>
        <h2 className={"accordion-header"} id={"accordionFillExample1"}>
          <button
            className={classnames("accordion-button", { collapsed: !price })}
            type={"button"}
            onClick={handlePriceClick}
            style={{ cursor: "pointer" }}
          >
            Цена
          </button>
        </h2>
        <Collapse
          isOpen={price}
          className={"accordion-collapse"}
          id={"accor_price"}
        >
          <AccordionBody id={"accordionFill"}>
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
        </Collapse>
      </AccordionItem>
      <AccordionItem>
        <h2 className={"accordion-header"} id={"accordionFillExample1"}>
          <button
            className={classnames("accordion-button", {
              collapsed: !manufactures,
            })}
            type={"button"}
            onClick={handleManufacturesClick}
            style={{ cursor: "pointer" }}
          >
            Производители
          </button>
        </h2>
        <Collapse
          isOpen={manufactures}
          className={"accordion-collapse"}
          id={"accor_manufactures"}
        >
          <AccordionBody id={"accordionFill"}>
            <Select options={manufactureArr} defaultValue={[]} />
          </AccordionBody>
        </Collapse>
      </AccordionItem>
      <AccordionItem>
        <h2 className={"accordion-header"} id={"accordionFillExample1"}>
          <button
            className={classnames("accordion-button", { collapsed: !rating })}
            type={"button"}
            onClick={handleRatingClick}
            style={{ cursor: "pointer" }}
          >
            Рейтинг
          </button>
        </h2>
        <Collapse
          isOpen={rating}
          className={"accordion-collapse"}
          id={"accor_rating"}
        >
          <AccordionBody id={"accordionFill"}>
            <Rating
              initialRating={0}
              emptySymbol={"mdi mdi-star-outline text-muted"}
              fullSymbol={"mdi mdi-star text-warning"}
            />
          </AccordionBody>
        </Collapse>
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
    </Accordion>
  );
};

export { ProductSort };
