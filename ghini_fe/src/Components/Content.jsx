import React from "react";
import ProductCard from "./ProductCard";
import { Grid } from "@material-ui/core";
import ProductMakerList from "./constants";

const Content = () => {
  const getProductMakerCard = ProductMakerObj => {
    return (
      <Grid item xs={12} sm={4}>
        <ProductCard {...ProductMakerObj} />
      </Grid>
    );
  };

  return (
    <Grid container spacing={2}>
      {ProductMakerList.map(ProductMakerObj => getProductMakerCard(ProductMakerObj))}
    </Grid>
  );
};

export default Content;