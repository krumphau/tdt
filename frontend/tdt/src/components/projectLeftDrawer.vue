<template>
        <q-drawer
        show-if-above
        :width="200"
        :breakpoint="400"
        >
            <q-img class="absolute-top" src="https://cdn.quasar.dev/img/material.png" style="height: 150px">
            <div class="absolute-top bg-transparent">
            <q-avatar size="56px" class="q-mb-sm">
                <img src="../assets/LogoOnTransparent.gif">
            </q-avatar>
            </div>
            </q-img>
            <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
            <q-list padding>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="subject" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/details">Details</q-btn>
                </q-item-section>
                </q-item>

                <q-item active clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="assignment" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/notes" >Notes</q-btn>
                </q-item-section>
                </q-item>

                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="language" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/website" >Web Site</q-btn>
                </q-item-section>
                </q-item>

                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="widgets" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/categories" >Categories</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="description" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/documents" >Documents</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="account_balance" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/funders" >Funders</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="location_city" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/ngos" >NGOs</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="work" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/otherbodies" >Other Bodies</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="shopping_cart" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/purchaseditems" >Purchased Items</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="mood" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/visits" >Visit Dates</q-btn>
                </q-item-section>
                </q-item>
                <q-item clickable v-ripple>
                <q-item-section avatar>
                    <q-icon name="extension" />
                </q-item-section>

                <q-item-section>
                    <q-btn flat no-caps to="/project/relatedprojects" >Related Projects</q-btn>
                </q-item-section>
                </q-item>
            </q-list>
            </q-scroll-area>
        </q-drawer>
</template>
