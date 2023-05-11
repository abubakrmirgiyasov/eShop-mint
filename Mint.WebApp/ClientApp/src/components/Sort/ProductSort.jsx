import React, { useState } from "react";
import {
  Accordion,
  AccordionBody,
  AccordionItem,
  Collapse,
  Input,
} from "reactstrap";
import classnames from "classnames";
import Select from "react-select";
import Rating from "react-rating";

const ProductSort = ({}) => {
  const [price, setPrice] = useState(true);
  const [manufactures, setManufactures] = useState(false);
  const [rating, setRating] = useState(false);

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
          <AccordionBody>
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
          <AccordionBody>
            <Select />
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
          <AccordionBody>
            <Rating
              initialRating={0}
              emptySymbol={"mdi mdi-star-outline text-muted"}
              fullSymbol={"mdi mdi-star text-warning"}
            />
          </AccordionBody>
        </Collapse>
      </AccordionItem>
    </Accordion>
  );
};

export { ProductSort };
